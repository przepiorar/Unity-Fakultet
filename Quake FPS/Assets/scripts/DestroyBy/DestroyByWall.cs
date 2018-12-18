using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByWall : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            Destroy(other.gameObject);
        }
        else
        {
            if (other.tag =="Enemy" || other.tag== "Player")
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                    rb.velocity = Vector3.zero;
            }
            return;
        }
    }
}
