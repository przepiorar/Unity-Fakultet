using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Plane" )
        {
            Library.gameController.player.grounded = true;
            Library.gameController.player.rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
        if ((other.tag == "Wall" || other.tag == "Enemy") && Library.gameController.player.grounded == false)
        {
            Vector3 movement = transform.up * -1f;
            Library.gameController.player.rb.MovePosition(Library.gameController.player.rb.position + movement);
        }
        if (other.tag=="End")
        {
            // gameController.GameOver();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plane")
        {
            Library.gameController.player.grounded = false;
            Library.gameController.player.rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
}
