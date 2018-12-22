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
        if (other.tag =="Plane" || other.CompareTag("Wall"))
        {
           // Debug.Log(Vector3.Distance(this.transform.position, Library.gameController.player.transform.position).ToString());
            if (this.tag == "Shell")
            {
                Destroy(gameObject);
            }
            return;
        }
        else
        {
            if ((this.tag == "Shell"|| other.tag == "Sword") && (other.tag == "Shell" || other.tag == "Sword"))
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
