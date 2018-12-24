using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    public abstract void Shot();
    public float fireRate;
}
