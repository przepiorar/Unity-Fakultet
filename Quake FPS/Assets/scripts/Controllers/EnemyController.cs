using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject shot;
    public Transform[] shotSpawns;
    public float fireRate;
    public GameObject explosion;
    public int scoreValue;
    public int health;

   // public float xMin, xMax, zMin, zMax;

    // private AudioSource audioSource;
    public int MoveSpeed;
    public int MaxDist;
    public int MinDist;
    public Transform Player;

    private Rigidbody rb;
    private float nextFire;
    private Vector3 target;
    private bool stop;
    private Vector3 move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stop = false;
        // audioSource = GetComponent<AudioSource>();
    }

    void Fire()
    {
        foreach (var shotSpawn in shotSpawns)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        // audioSource.Play();
    }

    void Update()
    {
        if (Player != null )
        {
            target = new Vector3(Player.position.x, this.transform.position.y, Player.position.z);
            transform.LookAt(target);
            if (stop)
            {
                rb.transform.position -= 5*move;
                stop = false;
            }
            else
            {
                if (Vector3.Distance(rb.position, Player.position) <= MaxDist)
                {
                    if (Vector3.Distance(rb.position, Player.position) >= MinDist)
                    {
                        move = transform.forward * MoveSpeed * Time.deltaTime;
                        //if (new Vector3(xMin, (rb.transform.position + move).y, zMin) < rb.transform.position + move && Player.transform.position.x < xMax && zMin < Player.transform.position.z && Player.transform.position.z < zMax)

                       // if (xMin <(rb.transform.position + move)[0] && zMin< (rb.transform.position + move)[2] && (rb.transform.position + move)[0]<xMax && (rb.transform.position + move)[2]<zMax)
                       // {
                            rb.transform.position += move;
                      //  }
                    }
                    else
                    {
                        move = transform.forward * -MoveSpeed / 2 * Time.deltaTime;
                      //  if (xMin < (rb.transform.position + move)[0] && zMin < (rb.transform.position + move)[2] && (rb.transform.position + move)[0] < xMax && (rb.transform.position + move)[2] < zMax)
                      //  {
                            rb.transform.position += move;
                       // }
                    }
                    if (Time.time > nextFire)
                    {
                        Fire();
                        nextFire = Time.time + fireRate;
                    }
                }
            }
        }
    }

    public void TakeDamage(int damage)
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            stop = true;
        }
        //else
        //{
            //if (other.tag == "Enemy")
            //{
            //    rb.transform.position -= 4*move;
            //}
        //}
    }
}
