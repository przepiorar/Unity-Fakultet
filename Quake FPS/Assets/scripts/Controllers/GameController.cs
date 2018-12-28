using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public Text healthText;
    public Text ammoText;
    public Text weaponText;
    public PlayerController player;
    public List<AudioSource> killTexts;
    public GameObject shotLeft;
    public GameObject lightWall;
    public GameObject lightWall2;
    public Canvas endWindow;
    public Canvas pauseWindow;
    public Text endText;
    private int score;
    private bool pause;

    void Start ()
    {
        score = 0;
        pause = false;
        UpdateScore();
        Library.gameController = this;
        Cursor.visible = false;
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                PauseGame();
                pause = true;
            }
            else
            {
                ContinueGame();
                pause = false;
            }
        }
        if (lightWall!=null && 251 < player.transform.position.z)
        {
            lightWall.gameObject.SetActive(true);
        }
        if (lightWall2 != null &&  431 < player.transform.position.z)
        {
            lightWall2.gameObject.SetActive(true);
        }
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


    public void GameOver(bool b)
    {
        endWindow.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        if (b)
        {
            endText.text = "Wygrana!\nUdało Ci się uciec\nUzyskano: " + score.ToString() + " punktow";
        }
        else
        {
            endText.text = "Porażka!\nZostałeś zabity";
        }

    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseWindow.gameObject.SetActive(true);
        Cursor.visible = true;
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pauseWindow.gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void LeaveGame()
    {
        Application.Quit();
    }

    public void StayInGame()
    {
        Time.timeScale = 1;
        pauseWindow.gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        endWindow.gameObject.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
        Cursor.visible = false;
    }
}
