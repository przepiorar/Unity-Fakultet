using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : Weapon
{
    public GameObject shot;
    public Transform[] shotSpawns;
    public bool audio2;
    private AudioSource audioSource;


    void Start()
    {
        if (audio2)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public override void Shot()
    {
        if (audio2)
        {
            audioSource.Play();
        }
        foreach (var shotSpawn in shotSpawns)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}