using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
       GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.tag != "Boss" && other.tag != "Bonus")
       // {
           // if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
          //  {
           //     return;
           // }
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, transform.position, transform.rotation);
             //   gameController.GameOver();
            }
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
      //  }
    }
}
