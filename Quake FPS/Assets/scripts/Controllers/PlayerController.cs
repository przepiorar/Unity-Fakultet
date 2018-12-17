using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public Weapon[] weapons;
    [System.NonSerialized]
    public bool[] haveWeapons;
    [System.NonSerialized]
    public Weapon currentWeapon;
    [System.NonSerialized]
    public int currentWeaponId;
    [System.NonSerialized]
    public int[] ammoWeapons;
    public float speed;
    public float speedturn;
    public int health;

    public float JumpHeight;
    public GameObject playerExplosion;
    private float nextFire;
    private float nextJump;

    private Rigidbody rb;
    private GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // currentWeapon = weapons[0];
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        gameController.UpdateHealth();
        haveWeapons = new bool[weapons.Length];
        ammoWeapons = new int[weapons.Length];
        for (int i = 0; i < haveWeapons.Length; i++)
        {
            haveWeapons[i] = false;
            ammoWeapons[i] = 0;
        }
       // haveWeapons[0] = true;
       // ammoWeapons[0] = 20;
        currentWeaponId =-1;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && currentWeaponId != -1 && Time.time > nextFire && (ammoWeapons[currentWeaponId]>0 || currentWeaponId==2) )
        {
            currentWeapon.Shot();
            ammoWeapons[currentWeaponId]--;
            Library.gameController.UpdateAmmo(currentWeaponId);
            nextFire = Time.time + currentWeapon.fireRate;
        }
        if (Input.GetKey("1") && haveWeapons[0])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[0];
            weapons[0].gameObject.SetActive(true);
            currentWeaponId = 0;
            Library.gameController.UpdateAmmo(currentWeaponId);
        }
        if (Input.GetKey("2") && haveWeapons[1])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[1];
            weapons[1].gameObject.SetActive(true);
            currentWeaponId = 1;
            Library.gameController.UpdateAmmo(currentWeaponId);
        }
        if (Input.GetKey("3") && haveWeapons[2])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[2];
            weapons[2].gameObject.SetActive(true);
            currentWeaponId = 2;
            Library.gameController.UpdateAmmo(currentWeaponId);
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
        gameController.UpdateHealth();
        if (health <= 0)
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            // gameController.GameOver();
        }
    }
}

