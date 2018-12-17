using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickByContact : MonoBehaviour
{
    public int slot;
    public int ammo;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Library.gameController.player.haveWeapons[slot] = true;
            Library.gameController.player.ammoWeapons[slot] += ammo;
        }
        else
        {
            return;
        }
    }
}
