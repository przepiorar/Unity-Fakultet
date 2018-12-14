using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public Weapon weapon;
    public float speed;
    public float speedturn;
    public int health;

    private float nextFire;
    private float nextJump;

    private Rigidbody rb;
    private GameController gameController;


    public float JumpHeight;
    //public float GroundDistance;
   // public LayerMask Ground;
    
   // private bool _isGrounded = true;
   // private Transform _groundChecker;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        gameController.UpdateHealth();

       // _groundChecker = transform.GetChild(0);

    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            weapon.Shot();
            nextFire = Time.time + weapon.fireRate;
        }
        //_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);


        //_inputs = Vector3.zero;
        //_inputs.x = Input.GetAxis("Horizontal");
        //_inputs.z = Input.GetAxis("Vertical");
        //if (_inputs != Vector3.zero)
        //    transform.forward = _inputs;

        //if (Input.GetButtonDown("Jump") && _isGrounded)
        //{
        //    rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        //}
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
            rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight *-2 * Physics.gravity.y), ForceMode.VelocityChange);  //-2
            nextJump = 1f + Time.time;
        }
        
        //  rb.MovePosition(rb.position + _inputs * speed * Time.fixedDeltaTime);
    }
}

