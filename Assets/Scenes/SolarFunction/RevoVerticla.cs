using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RevoVerticla : MonoBehaviour
{
    public Transform target;
    public float revSpeed;
    public void RevVertical()
    {
        transform.RotateAround(target.position, Vector3.right, revSpeed * Time.deltaTime);
    }

    
    void Update()
    {
        RevVertical();
    }
}
