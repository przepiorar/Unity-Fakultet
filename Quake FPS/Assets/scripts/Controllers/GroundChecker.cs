﻿using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour
{
    public bool ramp;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Plane" )
        {
            Library.gameController.player.grounded = true;
            Library.gameController.player.rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
        if (other.tag =="Ramp")
        {
            ramp = true;
        }
        if ((other.tag == "Wall" || other.tag == "Enemy") && Library.gameController.player.grounded == false && !ramp)
        {
            Vector3 movement = transform.up * -1f;
            Library.gameController.player.rb.MovePosition(Library.gameController.player.rb.position + movement);
        }
        if (other.tag=="End")
        {
           Library.gameController.GameOver(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plane")
        {
            Library.gameController.player.grounded = false;
            Library.gameController.player.rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (other.tag == "Ramp")
        {
            ramp = false;
        }
    }
}