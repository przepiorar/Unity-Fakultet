using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaExplosion : MonoBehaviour
{
    public ParticleSystem explosion;
    public AudioSource m_ExplosionAudio;                
    public float m_MaxDamage;                      
    public float m_ExplosionRadius;                
    

    public void Boom()
    {
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;
            

            // Find the TankHealth script associated with the rigidbody.
            PlayerController targetHealth = targetRigidbody.GetComponent<PlayerController>();
            EnemyController enemytHealth = targetRigidbody.GetComponent<EnemyController>();

            // If there is no TankHealth script attached to the gameobject, go on to the next collider.
            if (!targetHealth && !enemytHealth)
                continue;

            // Calculate the amount of damage the target should take based on it's distance from the shell.
            int damage = CalculateDamage(targetRigidbody.position);

            // Deal this damage to the tank.
            if (targetHealth)
            {
                targetHealth.SetHealth(-damage);
            }
            else
            {
                enemytHealth.TakeDamage(damage);
            }
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }        
        m_ExplosionAudio.Play();
        Destroy(gameObject, 0.25f);
    }



    private int CalculateDamage(Vector3 targetPosition)
    {
        // Create a vector from the shell to the target.
        Vector3 explosionToTarget = targetPosition - transform.position;

        // Calculate the distance from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        // Calculate damage as this proportion of the maximum possible damage.
        float damage = relativeDistance * m_MaxDamage;

        // Make sure that the minimum damage is always 0.
        damage = Mathf.Max(0f, damage);

        return Mathf.RoundToInt(damage);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" || other.tag == "Plane" || other.tag =="Player")
        {
            Invoke("Boom",0);
        }
    }
}