using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propellerRotate : MonoBehaviour
{
    public int flyLimit;
    public Rigidbody rigid;


    private void Update()
    {
       if ( Input.GetButtonDown("Fly"))
        {
            Debug.Log("_____ is down");
        }
        if (Input.GetButton("Fly"))
        {
            Debug.Log("_____ is pressing");
        }
        if (Input.GetButtonUp("Fly"))
        {
            Debug.Log("_____ is up");
        }
    }

}
