using UnityEngine;
using System.Collections;

public class EnemyGunController : MonoBehaviour
{

    public Transform Player;
    private Vector3 target;
    private Vector3 move;

    void Update()
    {
        if (Player != null)
        {
            Vector3 relativePos = Player.position - target;

            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;


            //this.transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, Mathf.Sin((transform.localPosition.y-Player.transform.localPosition.y)/
            //    (Vector3.Distance(Player.position,transform.position))), transform.localRotation.eulerAngles.z);
            // target = new Vector3(this.transform.position.x, Player.position.y, this.transform.position.z);
            // transform.LookAt(target);
        }

    }
}
