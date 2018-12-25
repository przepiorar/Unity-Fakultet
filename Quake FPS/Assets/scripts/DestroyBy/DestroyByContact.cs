using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Plane" || other.CompareTag("Wall") || other.tag == "Ramp")
        {
           // Debug.Log(Vector3.Distance(this.transform.position, Library.gameController.player.transform.position).ToString());
            if (this.tag == "Shell" || this.tag == "EnemyShell")
            {
                PlasmaExplosion pe = GetComponent<PlasmaExplosion>();
                if (!pe)
                {
                  //  Instantiate(Library.gameController.shotLeft, transform.position-transform.forward*1.8f, transform.rotation);
                    Destroy(gameObject);
                }
                else
                    pe.Boom();
            }
            return;
        }
        else
        {
            if ((this.tag == "Shell"|| other.tag == "Sword") && (other.tag == "Shell" || other.tag == "Sword"))
            {
                return;
            }
            else
            {
                if (other.tag == "Shield" && this.tag !="EnemyShell")
                {
                    if (this.tag == "Shell")
                    {
                        ShieldController enemy = other.GetComponent<ShieldController>();
                        enemy.AbsorbDamage();
                        Destroy(gameObject);
                    }
                    else
                    {
                        if (this.tag == "Arrow")
                        {
                            Destroy(other.gameObject);
                        }
                    }
                }
                else
                {
                    if (other.tag == "Player")
                    {
                        Destroy(gameObject);
                        Library.gameController.player.SetHealth(-damage);
                    }
                    else
                    {
                        if (other.tag == "Enemy" && (this.tag == "Shell" || this.tag == "Arrow"))
                        {
                            Destroy(gameObject);
                            EnemyController enemy = other.GetComponent<EnemyController>();
                            enemy.TakeDamage(damage);
                        }
                    }
                    return;
                    // Destroy(other.gameObject);
                }
            }
        }
    }
}
