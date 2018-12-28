using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            rb.transform.position += transform.forward;
            rb.useGravity = true;
        }
        if (other.tag == "Wall")
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plane")
        {
            Destroy(gameObject);
        }
    }
}
