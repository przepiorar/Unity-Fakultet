using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDodge : MonoBehaviour {
    
    public Boundary boundary;    
    private Rigidbody rb;
    private bool moveleft;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveleft = true;
    }

    void FixedUpdate()
    {
        if (moveleft)
        {
            transform.position = new Vector3(transform.position.x,0, transform.position.z) + new Vector3(-0.02f,0,0);
            if (transform.position.x < -4)
            {
                moveleft = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z) + new Vector3(0.02f, 0, 0);
            if (transform.position.x > 4)
            {
                moveleft = true;
            }
        }

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
    }
}
