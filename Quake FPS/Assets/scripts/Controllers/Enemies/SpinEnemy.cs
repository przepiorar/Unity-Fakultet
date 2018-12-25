﻿using UnityEngine;
using System.Collections;

public class SpinEnemy : EnemyController
{    
    public int MoveSpeed;

    private AudioSource audioSource;
    private Rigidbody rb;
    private float nextFire;
    private Vector3 target;
    private bool stop;
    private Vector3 move;
    private bool active;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stop = false;
        audioSource = GetComponent<AudioSource>();
        active = false;
    }

    public override void Fire()
    {

    }

    void Update()
    {
        if (Player != null)
        {
            target = new Vector3(Player.position.x, this.transform.position.y, Player.position.z);
            transform.LookAt(target);
            if (stop)
            {
                rb.transform.position -= 10 * move;
                stop = false;
            }
            else
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
                            audioSource.Play();
                            nextFire = Time.time + 1.5f;
                        }
                        if (Vector3.Distance(rb.position, Player.position) >= MinDist)
                        {
                            move = transform.forward * MoveSpeed * Time.deltaTime;
                            //if (new Vector3(xMin, (rb.transform.position + move).y, zMin) < rb.transform.position + move && Player.transform.position.x < xMax && zMin < Player.transform.position.z && Player.transform.position.z < zMax)

                            // if (xMin <(rb.transform.position + move)[0] && zMin< (rb.transform.position + move)[2] && (rb.transform.position + move)[0]<xMax && (rb.transform.position + move)[2]<zMax)
                            // {
                            rb.transform.position += move;
                            //  }
                        }
                    }
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            stop = true;
        }
    }
}
