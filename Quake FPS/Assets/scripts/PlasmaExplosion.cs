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
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidbody)
                continue;            
            
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
        m_ExplosionAudio.Play();
        Destroy(gameObject, 0.25f);
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" || other.tag == "Plane" || other.tag =="Player")
        {
            Invoke("Boom",0);
        }
    }
}