using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{

    public int damage;
    public int spinSpeed;
    private float nextDamage;
   // private CapsuleCollider capsCollider;
    private BoxCollider capsCollider;

    private void Start()
    {
        capsCollider = GetComponent<BoxCollider>();
    }

    void Update ()
    {
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        if (Time.time > nextDamage)
        {
            capsCollider.isTrigger = true;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Time.time > nextDamage)
        {
            nextDamage = Time.time + 0.5f;
            PlayerController player = other.GetComponent<PlayerController>();
            player.SetHealth(-damage);
            capsCollider.isTrigger = false;
        }
        else
        {
            return;
        }
    }
}
