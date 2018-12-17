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
    public void Start()
    {
        target = startingPosition;
    }
    public override void Shot()
    {
        target = SwordHit;
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
