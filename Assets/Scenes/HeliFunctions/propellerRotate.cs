using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class propellerRotate : MonoBehaviour
{

    public Transform target;


    //public Rigidbody rigid;
    [Header("---------Propeller---------")]                 // �⺻ rpm
    private float angle = 1;
    [SerializeField] public float rpm = 1050;

    [Space]
    [Header("------Propeller Limit------")]                  // �����緯 ����
    [SerializeField] public float maxRPM = 10500;
    public float minRPM = 0;
    public float goalRPM = 4200;
    private float curRPM;
    [Space(2)]

    [Header("--------LevitatePower--------")]               // �η�
    [Range(1,10)][SerializeField]public float flyPower = 1;
    private float maxFlyPower = 10;
    private float minFlyPower = 0;
    private float curFlyPower;
    [Space(2)]

    // ���� ����
    [Header("---------AltitudeControl---------")]           // �� ����
    private float minAltitude = 0;
    private float maxAltitude = 50;
    private float curAltitude;
    [Space(2)]


    [Header("---------Movement---------")]                  // ������
    [SerializeField] float moveSpeed = 50;
    [SerializeField] float rotateSpeed = 50;



    private void Update()
    {

        Spin();
        Fly();
        Move();

        // ��ư Ȯ����
        #region ��ưȮ��

        if (Input.GetButton("Fly"))
        {
            Debug.LogWarning($"Fly Button is pressing\n" +
                $"RPM: {curRPM}");
        }

        #endregion
    }
    private void Spin() // �����緯�� �������� �߽����� ȸ��
    {
        if (Input.GetButton("Fly"))
        {
            // delTime���� frame/sec ���� �Էµǰ������� rpm ����
            curRPM += rpm * Time.deltaTime;
            transform.RotateAround(target.position, Vector3.up, curRPM * Time.deltaTime);
            if (curRPM >= maxRPM)
            {// rpm�� �ִ�ġ �����ϸ� �� �� ����
                curRPM = maxRPM;
            }
        }
    }


    // < ���� >
    // Ư�� rpm �Ѿ�� ���󰡴� ��� �߰��ؾ���.
    private void Fly() // ����, Ư�� rpm �Ѿ�� ���� ��� �߰��ؾ���
    {
        float y = Input.GetAxis("Fly");
        if (Input.GetButton("Fly") && curRPM >= goalRPM)
        {   
            // �η� ����
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
