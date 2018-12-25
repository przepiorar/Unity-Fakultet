using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public ParticleSystem explosion;
    public AudioSource m_ExplosionAudio;
    public float m_MaxDamage;                    
    public float m_ExplosionForce;              
    public float m_MaxLifeTime;                   
    public float m_ExplosionRadius;                

    private void Start()
    {
        Invoke("Boom", m_MaxLifeTime);
        Invoke("Explosion", 2.75f);
    }

    private void Boom()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidbody)
                continue;
            
            targetRigidbody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            PlayerController targetHealth = targetRigidbody.GetComponent<PlayerController>();
            EnemyController enemytHealth = targetRigidbody.GetComponent<EnemyController>();
            
            if (!targetHealth && !enemytHealth)
                continue;
            
            int damage = CalculateDamage(targetRigidbody.position);
            
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
        Destroy(gameObject, 0.25f);
    }

    private void Explosion()
    {
        m_ExplosionAudio.Play();
    }



    private int CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
        float damage = relativeDistance * m_MaxDamage;
        damage = Mathf.Max(0f, damage);
        return Mathf.RoundToInt(damage);
    }
}