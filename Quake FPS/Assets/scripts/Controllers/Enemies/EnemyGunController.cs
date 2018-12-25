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
             Vector3 relativePos = Player.position - transform.position;
            //relativePos[0] = relativePos[1];

           Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            //rotation[1] = transform.rotation[1];
            //rotation[2] = transform.rotation[2];
            transform.rotation = rotation;


            // transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, -Mathf.Cos((transform.localPosition.y - Player.transform.localPosition.y) /
            //    (Vector3.Distance(Player.position, transform.position))), transform.localRotation.eulerAngles.z);
           // target = new Vector3(transform.position.y, Player.position.y, transform.position.z);
           // transform.LookAt(target);
        }
    }
}
