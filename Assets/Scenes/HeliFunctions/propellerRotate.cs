using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class propellerRotate : MonoBehaviour
{
    public int flyLimit;
    public Rigidbody rigid;

    [SerializeField] float angle;
    [SerializeField] float revolutionPower;


    public Transform target;

    private void Update()
    {
       RotateAround();
       if ( Input.GetButtonDown("Fly"))
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

}
