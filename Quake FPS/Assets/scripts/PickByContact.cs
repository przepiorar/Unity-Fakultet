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
            if (Library.gameController.player.currentWeaponId !=-1)
            {
                Library.gameController.player.currentWeapon.gameObject.SetActive(false);
            }
            Library.gameController.player.currentWeapon = Library.gameController.player.weapons[slot];
            Library.gameController.player.weapons[slot].gameObject.SetActive(true);
            Library.gameController.player.currentWeaponId = slot;
            Library.gameController.UpdateAmmo(Library.gameController.player.currentWeaponId);
        }
        else
        {
            return;
        }
    }
}
