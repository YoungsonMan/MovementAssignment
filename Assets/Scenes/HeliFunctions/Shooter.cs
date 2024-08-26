using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody missile;
    public GameObject missile2;
 
    public Transform muzzlePoint;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
          //  Rigidbody rigid = Instantiate(missile, muzzlePoint.position, muzzlePoint.rotation);
          //  rigid.AddForce(Vector3.forward * 100, ForceMode.Impulse);
            GameObject instance = Instantiate(missile2, muzzlePoint.position, muzzlePoint.rotation);
            Bullet bullet = instance.GetComponent<Bullet>();
            

        }
        
    }

}
