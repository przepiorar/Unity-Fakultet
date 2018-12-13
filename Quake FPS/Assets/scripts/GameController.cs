using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;
    private int score;

    void Start ()
    {
        score = 0;
        UpdateScore();
    }
	
	void Update ()
    {
       // if (Input.GetKeyDown(KeyCode.R))  //lub esc i wyjscie
       // {
        //    Application.LoadLevel(Application.loadedLevel);
       // }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    //public void GameOver()
    //{
    //    Endtext.text = "Game Over!";
    //    end = true;
    //    RestartText.text = "Press R to restart";
    //    restart = true;
    //}
}
