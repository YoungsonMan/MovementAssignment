using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Revolving speed
    /* PLANET   |      YEARS     |  inGameSpeed |
     * Mercury  |   58.6 days    |     62286    |
     * Venus    |   243 days     |     15020    |
     * Earth    |   1.0 days     |    3649635   |
     * Mars     |   1.03 days    |    3546099   |
     * Jupiter  |   0.41 days    |    8928571   |
     * Saturn   |   0.45 days    |    8130081   |
     * Uranus   |   0.72 days    |    5076142   |
     * Neptune  |   0.67 days    |    5434783   |
     */

    public Transform target;
    public float rotSpeed;

    void Update()
    {
        Rotate();
    }
    public void Rotate()
    {
        transform.RotateAround(transform.position, Vector3.up, rotSpeed * Time.deltaTime);
    }

}
