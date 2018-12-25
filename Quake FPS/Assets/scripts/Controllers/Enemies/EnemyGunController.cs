using UnityEngine;
using System.Collections;

public class EnemyGunController : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        if (Player != null)
        {
             Vector3 relativePos = Player.position - transform.position;

            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }
    }
}
