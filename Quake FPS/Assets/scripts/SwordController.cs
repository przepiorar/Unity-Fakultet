using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : Weapon
{
    public int damage;
    public int speed;
    public Transform SwordHit;
    private Transform target;
    public Transform startingPosition;
   // private CapsuleCollider coll;
    public void Start()
    {
        target = startingPosition;
       // coll = GetComponent<CapsuleCollider>();
    }
    public override void Shot()
    {
        target = SwordHit;
       // coll.isTrigger = true;
        
    }
    private void Update()
    {
        transform.LookAt(target);
        if ( Vector3.Distance(transform.position, target.position) >= 0.1f)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            if (target == SwordHit)
            {
                target = startingPosition;
               // coll.isTrigger = false;
            }
            else
            {
                transform.position = startingPosition.position;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
