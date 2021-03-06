﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //[System.NonSerialized]
    public bool grounded;

    public List<AudioSource> textTakeDamage;
    public AudioSource changeWeaponSound;

    private float nextFire;
    [System.NonSerialized]
    public Rigidbody rb;
    private GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        gameController.UpdateHealth();
        grounded = true;
        haveWeapons = new bool[weapons.Length];
        ammoWeapons = new int[weapons.Length];
        for (int i = 0; i < haveWeapons.Length; i++)
        {
            haveWeapons[i] = false;
            ammoWeapons[i] = 0;
        }
        currentWeaponId =-1;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && currentWeaponId != -1 && Time.time > nextFire && (ammoWeapons[currentWeaponId]>0 || currentWeaponId==2 || currentWeaponId ==6) )
        {
            currentWeapon.Shot();
            if (currentWeaponId !=2 && currentWeaponId !=6)
            {
                ammoWeapons[currentWeaponId]--;
                Library.gameController.UpdateAmmo(currentWeaponId);
            }
            nextFire = Time.time + currentWeapon.fireRate;
        }
        if (Input.GetKey("1") && haveWeapons[0])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[0];
            weapons[0].gameObject.SetActive(true);
            currentWeaponId = 0;
            Library.gameController.UpdateAmmo(currentWeaponId);
            changeWeaponSound.Play();
            Library.gameController.weaponText.text = (currentWeaponId + 1).ToString() + ": pistolet";
        }
        if (Input.GetKey("2") && haveWeapons[1])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[1];
            weapons[1].gameObject.SetActive(true);
            currentWeaponId = 1;
            Library.gameController.UpdateAmmo(currentWeaponId);
            changeWeaponSound.Play();
            Library.gameController.weaponText.text = (currentWeaponId + 1).ToString() + ": granat";
        }
        if (Input.GetKey("3") && haveWeapons[2])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[2];
            weapons[2].gameObject.SetActive(true);
            currentWeaponId = 2;
            Library.gameController.UpdateAmmo(currentWeaponId);
            changeWeaponSound.Play();
            Library.gameController.weaponText.text = (currentWeaponId + 1).ToString() + ": pręt";
        }
        if (Input.GetKey("4") && haveWeapons[3])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[3];
            weapons[3].gameObject.SetActive(true);
            currentWeaponId = 3;
            Library.gameController.UpdateAmmo(currentWeaponId);
            changeWeaponSound.Play();
            Library.gameController.weaponText.text = (currentWeaponId + 1).ToString() + ": kusza";
        }
        if (Input.GetKey("5") && haveWeapons[4])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[4];
            weapons[4].gameObject.SetActive(true);
            currentWeaponId = 4;
            Library.gameController.UpdateAmmo(currentWeaponId);
            changeWeaponSound.Play();
            Library.gameController.weaponText.text = (currentWeaponId + 1).ToString() + ": karabin";
        }
        if (Input.GetKey("6") && haveWeapons[5])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[5];
            weapons[5].gameObject.SetActive(true);
            currentWeaponId = 5;
            Library.gameController.UpdateAmmo(currentWeaponId);
            changeWeaponSound.Play();
            Library.gameController.weaponText.text = (currentWeaponId + 1).ToString() + ": miotacz ognia";
        }
        if (Input.GetKey("7") && haveWeapons[6])
        {
            currentWeapon.gameObject.SetActive(false);
            currentWeapon = weapons[6];
            weapons[6].gameObject.SetActive(true);
            currentWeaponId = 6;
            Library.gameController.UpdateAmmo(currentWeaponId);
            changeWeaponSound.Play();
            Library.gameController.weaponText.text = (currentWeaponId + 1).ToString() + ": działo plazmowe";
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveVertical * speed;
        Vector3 movement2 = transform.right * moveHorizontal * speed;
        
        rb.MovePosition(rb.position + movement);
        rb.MovePosition(rb.position + movement2);

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * speedturn);
        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.AddForce(Vector3.up * (JumpHeight * -0.5f * Physics.gravity.y), ForceMode.VelocityChange); 
        }
    }

    public void SetHealth(int value)
    {
        health += value;
        if (health>100)
        {
            health = 100;
        }
        if (value<0)
        {
            int a =Random.Range(0, textTakeDamage.Count);
            textTakeDamage[a].Play();
        }
        gameController.UpdateHealth();
        if (health <= 0)
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver(false);
        }
    }
}