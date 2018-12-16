using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public Weapon[] weapons;
   // [Non.Serializable ]
    [System.NonSerialized]
    public Weapon currentWeapon;
    public float speed;
    public float speedturn;
    public int health;

    public float JumpHeight;
    public GameObject playerExplosion;
    private float nextFire;
    private float nextJump;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Library.gameController.UpdateHealth();
        currentWeapon = weapons[0];
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            currentWeapon.Shot();
            nextFire = Time.time + currentWeapon.fireRate;
        }
        if (Input.GetKey("1"))
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[0];
            weapons[0].gameObject.SetActive(true);
        }
        if (Input.GetKey("2"))
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[1];
            weapons[1].gameObject.SetActive(true);
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
        if (Input.GetButtonDown("Jump") && Time.time > nextJump)
        {
            rb.AddForce(Vector3.up * (JumpHeight *-0.5f * Physics.gravity.y), ForceMode.VelocityChange);  //-2
            nextJump = 1.5f + Time.time;
        }
    }

    public void SetHealth(int value)
    {
        health += value;
        Library.gameController.UpdateHealth();
        if (health <= 0)
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            // gameController.GameOver();
        }
    }
}

