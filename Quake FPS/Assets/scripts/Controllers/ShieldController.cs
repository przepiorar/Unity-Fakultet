using UnityEngine;
using System.Collections;

public class ShieldController : MonoBehaviour
{
    public int health;

    public void AbsorbDamage()
    {
        health--;
        Renderer r = GetComponent<Renderer>();
        r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, r.material.color.a-0.1f);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
