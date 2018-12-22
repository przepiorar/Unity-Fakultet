using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public ParticleSystem explosion;
    public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
    public float m_MaxDamage;                    // The amount of damage done if the explosion is centred on a tank.
    public float m_ExplosionForce;              // The amount of force added to a tank at the centre of the explosion.
    public float m_MaxLifeTime;                    // The time in seconds before the shell is removed.
    public float m_ExplosionRadius;                // The maximum distance away from the explosion tanks can be and are still affected.

    private void Start()
    {
        Invoke("Boom", m_MaxLifeTime);
        Invoke("Explosion", 2.75f);
    }

    private void Boom()
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

            // Add an explosion force.
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);

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

        // Play the explosion sound effect.

        // Once the particles have finished, destroy the gameobject they are on.
        Destroy(gameObject, 0.25f);

        // Destroy the shell.
    }

    private void Explosion()
    {
        m_ExplosionAudio.Play();
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
}