using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerEnemy : EnemyController
{
    public GameObject shot;
    public Transform[] shotSpawns;
    public float fireRate;

    public List<GameObject> towerWalls;
    public List<Transform> partWallsSpawns;
    public GameObject partWall;
    public bool tower;

    private AudioSource audioSource;
    private Rigidbody rb;
    private float nextFire;
    private Vector3 target;
    private Vector3 move;
    private bool active;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        active = false;
    }

    public override void Fire()
    {
        foreach (var shotSpawn in shotSpawns)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        audioSource.Play();
    }

    void Update()
    {
        if (tower)
        {
            if (towerWalls.Count == 5 && health < 400)
            {
                towerWalls[4].SetActive(false);
                towerWalls.RemoveAt(4);
                foreach (var spawn in partWallsSpawns)
                {
                    Instantiate(partWall, spawn.position, spawn.rotation);
                }
            }
            if (towerWalls.Count == 4 && health < 300)
            {
                towerWalls[3].SetActive(false);
                towerWalls.RemoveAt(3);
                foreach (var spawn in partWallsSpawns)
                {
                    Instantiate(partWall, spawn.position, spawn.rotation);
                }
            }
            if (towerWalls.Count == 3 && health < 200)
            {
                towerWalls[2].SetActive(false);
                towerWalls.RemoveAt(2);
                foreach (var spawn in partWallsSpawns)
                {
                    Instantiate(partWall, spawn.position, spawn.rotation); ;
                }
            }
            if (towerWalls.Count == 2 && health < 100)
            {
                towerWalls[1].SetActive(false);
                towerWalls.RemoveAt(1);
                foreach (var spawn in partWallsSpawns)
                {
                    Instantiate(partWall, spawn.position, spawn.rotation);
                }
            }
        }
        if (Player != null)
        {
            if (initValueMoreThenEnemyPos)  //enemy value is more than initAxis
            {
                if (initAxis.Count == 0 || ((initAxis[0] == 0 || initAxis[0] < Player.transform.position.x) && (initAxis[1] == 0 || initAxis[1] < Player.transform.position.y)
                    && (initAxis[2] == 0 || initAxis[2] < Player.transform.position.z)))
                {
                    active = true;
                }
            }
            else
            {
                if (initAxis.Count == 0 || ((initAxis[0] == 0 || initAxis[0] > Player.transform.position.x) && (initAxis[1] == 0 || initAxis[1] > Player.transform.position.y)
                   && (initAxis[2] == 0 || initAxis[2] > Player.transform.position.z)))
                {
                    active = true;
                }
            }
            if (active)
            {
                if (Vector3.Distance(rb.position, Player.position) <= MaxDist)
                {
                    if (Time.time > nextFire)
                    {
                        Fire();
                        nextFire = Time.time + fireRate;
                    }
                }
            }
        }
    }
}
