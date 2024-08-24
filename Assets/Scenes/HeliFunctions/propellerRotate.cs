using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class propellerRotate : MonoBehaviour
{

    public Transform target;


    //public Rigidbody rigid;
    [Header("---------Propeller---------")]                 // 기본 rpm
    private float angle = 1;
    [SerializeField] public float rpm = 1050;

    [Space]
    [Header("------Propeller Limit------")]                 // 프로펠러 제어
    [SerializeField] public float maxRPM = 10500;           // 최대 회전속도    
    public float minRPM = 0;
    public float goalRPM = 4200;                            // 이륙을 위한 회전속도
    private float curRPM;                                   // 현재 회전속도
    [Space(2)]

    [Header("--------LevitatePower--------")]               // 부력
    [Range(1,10)][SerializeField]public float flyPower = 1; // 뜨는 힘
    private float maxFlyPower = 10;                         // 최대 힘 - 너무 확떠버리면 고도제한 50밖에 안되서 노잼    
    private float minFlyPower = 0;
    private float curFlyPower;
    [Space(2)]

    // 높이 제한
    [Header("---------AltitudeControl---------")]           // 고도 제어
    private float minAltitude = 0;
    private float maxAltitude = 50;
    private float curAltitude;
    [Space(2)]


    [Header("---------Movement---------")]                  // 움직임
    [SerializeField] public float moveSpeed = 5;
    [SerializeField] public float rotateSpeed = 100;


    private void LateUpdate() //LateUpdate로 업데이트에서 작동 다한 후에 되게하기
    {
        // 손땐거 감지하면 현재rpm 반토막
        if (Input.GetButtonUp("Fly")) // 설정에서 키워드 "Fly"로
        {
            curRPM /= 2;
        }
        
        
    }

    private void Update()
    {

        Spin();
        Fly();
        Move();

        // 버튼 확인차
        #region 버튼확인

        if (Input.GetButton("Fly"))
        {
            Debug.LogWarning($"Fly Button is pressing\n" +
                $"RPM: {curRPM}\t" + $"Altitude: {curAltitude}");
        }

        #endregion
    }
    private void Spin() // 프로펠러가 기준점을 중심으로 회전
    {
        if (Input.GetButton("Fly"))
        {
            // deltaTime으로 frame/sec 마다 입력되고있으면 rpm 증가
            curRPM += rpm * Time.deltaTime;
            transform.RotateAround(target.position, Vector3.up, curRPM * Time.deltaTime);
            if (curRPM >= maxRPM)
            {// rpm이 최대치 도달하면 그 값 유지
                curRPM = maxRPM;
            }
       
        }
    }


    // < 날기 >
    // 특정 rpm 넘어야 날라가는 기능 추가해야함.
    private void Fly() // 날기
    {
        float y = Input.GetAxis("Fly");
        if (Input.GetButton("Fly") && curRPM >= goalRPM) //특정 rpm 넘어야 
        {
            // 부력 가속
            curFlyPower += flyPower * Time.deltaTime;
            flyPower += curFlyPower / 10 * Time.deltaTime; // 올라가는 속도 가속
            target.Translate(Vector3.up.normalized * y * flyPower * Time.deltaTime);

            // 최고높이 제한 두기
            curAltitude = target.position.y;
            if(curAltitude >= maxAltitude)
            {
                curAltitude = maxAltitude;
                target.Translate(Vector3.down.normalized * y * flyPower * Time.deltaTime);
                // 같은 힘으로 다운포스줘서 못올라가게 하기
            }      
        }
        // 입력 안되면 내려가기
        if (Input.GetButton("Fly") != true)
        {
            int downForce = 5;
            target.Translate(Vector3.down * downForce * Time.deltaTime);
            // 0밑, 땅파고 내려가지 않도록 제한두기
            curAltitude = target.position.y;
            if (curAltitude <= minAltitude)
            {   // 땅파고 계속안내려가게 0되면 위에 같은힘으로 상쇄.
                target.Translate(Vector3.up * downForce * Time.deltaTime); 
            }
        }


    }
    private void Move()
    {
        // 키입력 받기    
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 움직임, 스페이스.셀프로 각도바꿔서 움직이게하기
        target.Translate(Vector3.forward.normalized * z * moveSpeed * Time.deltaTime, Space.Self);
        target.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);
    }

}
