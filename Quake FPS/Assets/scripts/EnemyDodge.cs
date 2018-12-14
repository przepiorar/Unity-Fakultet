using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodge : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 20;
    int MinDist = 10;

    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        transform.LookAt(Player);
        if (Vector3.Distance(rb.position, Player.position) >= MinDist)
        {
            rb.transform.position += transform.forward * MoveSpeed * Time.deltaTime;


            if (Vector3.Distance(rb.position, Player.position) <= MaxDist )
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }
}
