using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public Weapon weapon;
    public float speed;
    public float speedturn;

    private float nextFire;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            weapon.Shot();
            nextFire = Time.time + weapon.fireRate;
        }
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = transform.forward * moveVertical * speed;
        Vector3 movement2 = transform.right * moveHorizontal * speed;

        // Apply this movement to the rigidbody's position.
        rb.MovePosition(rb.position + movement);
        rb.MovePosition(rb.position + movement2);

        //rb.transform.position += new Vector3(moveHorizontal*speed,0, moveVertical*speed);  dobre
        //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0)  * speedturn);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * speedturn);  //dobre
    }
}

