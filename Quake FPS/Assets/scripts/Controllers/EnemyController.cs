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

    // private AudioSource audioSource;
    public int MoveSpeed;
    public int MaxDist;
    public int MinDist;
    public Transform Player;

    private Rigidbody rb;
    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        transform.LookAt(Player);
        if (Vector3.Distance(rb.position, Player.position) <= MaxDist)
        {
            if (Vector3.Distance(rb.position, Player.position) >= MinDist)
            {
                rb.transform.position += transform.forward * MoveSpeed * Time.deltaTime;                
            }
            if (Time.time > nextFire) 
            {
                Fire();
                nextFire = Time.time + fireRate;
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
}
