using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour {

    // public float xMin, xMax, zMin, zMax;
    public GameObject explosion;
    public int scoreValue;
    public int health;   
    public int MaxDist;
    public float MinDist;
    public Transform Player;

    public ShieldController shield;    
    public List<float> initAxis;

    public abstract void Fire();


    public void TakeDamage(int damage)
    {
        if (shield != null)
        {
            shield.AbsorbDamage();
        }
        else
        {
            health -= damage;
            if (health <= 0)
            {
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }
                Library.gameController.AddScore(scoreValue);
                Destroy(gameObject);
            }
        }
    }

    //public abstract void OnTriggerEnter(Collider other);
}
