using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Plane")
        {
            Library.gameController.player.grounded = true;
            Library.gameController.player.rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
        if ((other.tag == "Wall" || other.tag == "Enemy") && Library.gameController.player.grounded == false)
        {
            // Library.gameController.player.odbicie = true;
            Vector3 movement = transform.up * -1f;
            Library.gameController.player.rb.MovePosition(Library.gameController.player.rb.position + movement);

            // Vector3 movement = transform.forward * -2f;


            // Library.gameController.player.rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            //  Library.gameController.player.rb.MovePosition(Library.gameController.player.rb.position + movement);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plane")
        {
            Library.gameController.player.grounded = false;
            Library.gameController.player.rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        //if (other.tag == "Wall" || other.tag == "Enemy")
        //{
        //    Library.gameController.player.rb.constraints = RigidbodyConstraints.FreezeRotation;
        //}
    }
}
