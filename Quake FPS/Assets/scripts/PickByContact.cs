using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickByContact : MonoBehaviour
{
    public int slot;
    public int ammo;
    public AudioSource audioSource;
    public bool gun;
    public bool heal;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            audioSource.Play();
            if (heal)
            {
                Library.gameController.player.SetHealth(ammo);
            }
            else
            {
                Library.gameController.player.ammoWeapons[slot] += ammo;
                if (gun)
                {
                    Library.gameController.player.haveWeapons[slot] = true;
                    if (Library.gameController.player.currentWeaponId != -1)
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
                    if (Library.gameController.player.currentWeaponId == slot)
                    {
                        Library.gameController.UpdateAmmo(Library.gameController.player.currentWeaponId);
                    }
                }
            }
        }
        else
        {
            return;
        }
    }
}
