using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter(Collider other)
    {
        //if (other.tag != "Boss" && other.tag != "Bonus")
        // {
        if (other.CompareTag("Plane") || other.CompareTag("Wall"))
        {
            if (this.tag == "Shell")
            {
                Destroy(gameObject);
            }
            return;
        }
        else
        {
            if (this.tag == "Shell" && other.tag == "Shell")
            {
                return;
                //Destroy(gameObject);
                //Destroy(other.gameObject);
            }
            else
            {
                Destroy(gameObject);
                if (other.tag == "Player")
                {
                    Library.gameController.player.SetHealth(-damage);
                }
                else
                {
                    if (other.tag == "Enemy")
                    {
                        EnemyController enemy = other.GetComponent<EnemyController>();
                        enemy.TakeDamage(damage);
                    }
                    return;
                    // Destroy(other.gameObject);
                }
            }
        }
        //  }
    }
}
