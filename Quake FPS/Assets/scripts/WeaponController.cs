using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : Weapon
{
    public GameObject shot;
    public Transform[] shotSpawns;
    public float delay;

    // private AudioSource audioSource;

    void Start()
    {
        // audioSource = GetComponent<AudioSource>();
     // InvokeRepeating("Shot", delay, fireRate);
    }

    public override void Shot()
    {
        // audioSource.Play();
        foreach (var shotSpawn in shotSpawns)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}