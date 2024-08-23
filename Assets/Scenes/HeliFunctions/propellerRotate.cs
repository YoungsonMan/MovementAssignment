using UnityEngine;

public class propellerRotate : MonoBehaviour
{
    public int flyLimit;
    public Rigidbody rigid;

    [SerializeField] float angle;
    [SerializeField] float revolutionPower;
    public float flyPower;


    public Transform target;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir == Vector3.zero)
            return;
        target.Translate(moveDir.normalized * flyPower * Time.deltaTime, Space.World);

        RotateAround();
        Fly();

        if (Input.GetButtonDown("Fly"))
        {
            Debug.Log("Fly Button is down");
        }
        if (Input.GetButton("Fly"))
        {
            Debug.Log("Fly Button is pressing");
        }
        if (Input.GetButtonUp("Fly"))
        {
            Debug.Log("Fly Button is up");
        }
    }
    private void RotateAround() // 기준점을 중심으로 회전
    {
        transform.RotateAround(target.position, Vector3.up, revolutionPower * Time.deltaTime);
    }

    private void Fly()
    {
        float y = Input.GetAxis("Fly");
        if (Input.GetButton("Fly"))
        { 
            target.Translate(Vector3.up.normalized * y * flyPower * Time.deltaTime);
        }
    }

}
