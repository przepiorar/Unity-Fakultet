using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject shot;
    public Transform[] shotSpawns;
    public float fireRate;

    // private AudioSource audioSource;
    public Transform Player;
    public int MoveSpeed;
    public int MaxDist;
    public int MinDist;

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

                if (Vector3.Distance(rb.position, Player.position) <= MaxDist && Time.time > nextFire) //Here Call any function U want Like Shoot at here or something
                {
                    Fire();
                    nextFire = Time.time + fireRate;
                }
            }
        }
    }
}
