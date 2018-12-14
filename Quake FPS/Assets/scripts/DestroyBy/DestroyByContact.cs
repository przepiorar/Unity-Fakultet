using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int health;
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
        if (other.CompareTag("Plane") || other.CompareTag("Wall"))
        {
            if (this.tag == "Shell")
            {
                Destroy(gameObject);
            }
            return;
        }
        else
        {
            health--;
            if (health <= 0)
            {
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }
                gameController.AddScore(scoreValue);
                Destroy(gameObject);
            }
            if (other.tag == "Player")
            {
                gameController.player.health--;
                gameController.UpdateHealth();

                if (gameController.player.health <= 0)
                {
                    Instantiate(playerExplosion, transform.position, transform.rotation);
                    // gameController.GameOver();
                }
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
        //  }
    }
}
