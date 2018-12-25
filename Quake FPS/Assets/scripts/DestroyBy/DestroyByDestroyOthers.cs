using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDestroyOthers : MonoBehaviour
{
    public List<EnemyController> Enemies;
	
	void Update ()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i] != null)
            {
                break;
            }
            if (i+1== Enemies.Count)
            {
                Destroy(gameObject);
            }
        }
	}
}
