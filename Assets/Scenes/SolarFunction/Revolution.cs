using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{
    // Object to rotate around
    // Mostly the Sun would be the target for planets but the Earth for the Moon.
    public Transform target;

    // Revolving speed
    /* PLANET   |     YEARS     | inGameSpeed |
     * Mercury  |   0.24 yrs    |     416.67  |  
     * Venus    |   0.61 yrs    |     163.93  |
     * Earth    |   1.0 yrs     |     100     | 
     * Mars     |   1.88 yrs    |     53.19   |
     * Jupiter  |   11.86 yrs   |     8.43    |  
     * Saturn   |   29.46 yrs   |     3.39    |  
     * Uranus   |   84.01 yrs   |     1.19    |  
     * Neptune  |   164.79 yrs  |     0.61    |
     */
    public float revSpeed;

    private void Start()
    {
        
    }
    void Update()
    {
        Revolve();
    }

    // Revolution
    public void Revolve()
    {
        transform.RotateAround(target.position, Vector3.up, revSpeed * Time.deltaTime);
    }

    
}
