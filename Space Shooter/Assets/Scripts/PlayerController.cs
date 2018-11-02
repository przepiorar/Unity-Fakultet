using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    
    private Rigidbody rb;
    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform[] shotSpawns;   //gdyby był to gameobject musielibyśmy robić shotspawn.transform.position...
    public float fireRate;

    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
     void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        float moveHoriziontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = speed * new Vector3(moveHoriziontal, 0.0f, moveVertical);

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
    }
}
