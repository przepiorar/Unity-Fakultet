using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBonus : MonoBehaviour {
    
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            gameController.ActiveBonus();
        }
    }
}
