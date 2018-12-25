using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public Text healthText;
    public Text ammoText;
    public PlayerController player;
    public List<AudioSource> killTexts;
    public GameObject shotLeft;
    private int score;

    void Start ()
    {
        score = 0;
        UpdateScore();
        Library.gameController = this;
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
        if (score > 0)
        {
            int a = Random.Range(0, killTexts.Count);
            killTexts[a].Play();
        }
        scoreText.text = "Wynik: " + score.ToString();
    }

    public void UpdateHealth()
    {
        healthText.text = "Życie: " + player.health.ToString();
    }

    public void UpdateAmmo(int a)
    {
        if (a==2 || a==6)
        {
            ammoText.text = "Amunicja: --";
        }
        else
        ammoText.text = "Amunicja: " + player.ammoWeapons[a].ToString();
    }

    //public void GameOver()
    //{
    //    Endtext.text = "Game Over!";
    //    end = true;
    //    RestartText.text = "Press R to restart";
    //    restart = true;
    //}
}
