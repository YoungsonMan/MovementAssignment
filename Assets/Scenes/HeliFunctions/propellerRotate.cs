using JetBrains.Annotations;
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
    [Header("------Propeller Limit------")]                  // 프로펠러 제어
    [SerializeField] public float maxRPM = 10500;
    public float minRPM = 0;
    public float goalRPM = 4200;
    private float curRPM;
    [Space(2)]

    [Header("--------LevitatePower--------")]               // 부력
    [Range(1,10)][SerializeField]public float flyPower = 1;
    private float maxFlyPower = 10;
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
    [SerializeField] float moveSpeed = 50;
    [SerializeField] float rotateSpeed = 50;



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
                $"RPM: {curRPM}");
        }

        #endregion
    }
    private void Spin() // 프로펠러가 기준점을 중심으로 회전
    {
        if (Input.GetButton("Fly"))
        {
            // delTime으로 frame/sec 마다 입력되고있으면 rpm 증가
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
    private void Fly() // 날기, 특정 rpm 넘어야 도는 기능 추가해야함
    {
        float y = Input.GetAxis("Fly");
        if (Input.GetButton("Fly") && curRPM >= goalRPM)
        {   
            // 부력 가속
            curFlyPower += flyPower * Time.deltaTime;
            target.Translate(Vector3.up.normalized * y * flyPower * Time.deltaTime);
        }

    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
    


        target.Translate(Vector3.forward.normalized * z * moveSpeed * Time.deltaTime, Space.Self);
        target.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);
    }

}
