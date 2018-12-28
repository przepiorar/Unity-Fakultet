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
                    switch (slot)
                    {
                        case 0:
                            Library.gameController.weaponText.text = (slot + 1).ToString() + ": pistolet";
                            break;
                        case 1:
                            Library.gameController.weaponText.text = (slot + 1).ToString() + ": granat";
                            break;
                        case 2:
                            Library.gameController.weaponText.text = (slot + 1).ToString() + ": pręt";
                            break;
                        case 3:
                            Library.gameController.weaponText.text = (slot + 1).ToString() + ": kusza";
                            break;
                        case 4:
                            Library.gameController.weaponText.text = (slot + 1).ToString() + ": karabin";
                            break;
                        case 5:
                            Library.gameController.weaponText.text = (slot + 1).ToString() + ": miotacz ognia";
                            break;
                        case 6:
                            Library.gameController.weaponText.text = (slot + 1).ToString() + ": działo plazmowe";
                            break;

                        default:
                            break;
                    }
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
