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

    public List<AudioSource> textTakeDamage;

    private float nextFire;
    private float nextJump;
    private Rigidbody rb;
    private GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        //haveWeapons[3] = true;
        //ammoWeapons[3] = 20;
        currentWeaponId =-1;
       // currentWeapon = weapons[0];
       // haveWeapons[0] = true;
       // ammoWeapons[0] = 20;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && currentWeaponId != -1 && Time.time > nextFire && (ammoWeapons[currentWeaponId]>0 || currentWeaponId==2 || currentWeaponId ==6) )
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
        if (Input.GetKey("4") && haveWeapons[3])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[3];
            weapons[3].gameObject.SetActive(true);
            currentWeaponId = 3;
            Library.gameController.UpdateAmmo(currentWeaponId);
        }
        if (Input.GetKey("5") && haveWeapons[4])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[4];
            weapons[4].gameObject.SetActive(true);
            currentWeaponId = 4;
            Library.gameController.UpdateAmmo(currentWeaponId);
        }
        if (Input.GetKey("6") && haveWeapons[5])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[5];
            weapons[5].gameObject.SetActive(true);
            currentWeaponId = 5;
            Library.gameController.UpdateAmmo(currentWeaponId);
        }
        if (Input.GetKey("7") && haveWeapons[6])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[6];
            weapons[6].gameObject.SetActive(true);
            currentWeaponId = 6;
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
          //  rb.useGravity = true;
        }
    }

    public void SetHealth(int value)
    {
        health += value;
        if (value<0)
        {
            int a =Random.Range(0, textTakeDamage.Count);
            textTakeDamage[a].Play();
        }
        gameController.UpdateHealth();
        if (health <= 0)
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            // gameController.GameOver();
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Plane")
    //    {
    //        rb.useGravity = false;
    //    }
    //}
}

