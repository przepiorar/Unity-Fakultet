using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public GameObject[] bosses;
    public Vector3 spawnValues;
    public int hazardCount;   // ilość asteroid w fali
    public float spawnWait;  // czas między asteroidami w fali
    public float startWait; // czas od startu do 1 fali
    public float waveWait; // czas miedzy falami
    public float vavesUntilBoss;
    private float bossCount;

    public Text scoreText;
    private int score;
    public Text RestartText;
    public Text Endtext;

    public bool end;
    public bool restart;
    public bool deadBoss;

    void Start()
    {
        score = 0;
        UpdateScore();
        end = false;
        restart = false;
        RestartText.text = "";
        Endtext.text = "";
        StartCoroutine(SpawnWaves());
        bossCount = 0;
        deadBoss = true;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!end)
        {
            if (bossCount < vavesUntilBoss)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                    bossCount++;
                }
                yield return new WaitForSeconds(waveWait);
            }
            else
            {
                GameObject boss = bosses[Random.Range(0, bosses.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(boss, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait*2);
                bossCount = 0;

                deadBoss = false;

                while (!deadBoss)
                {
                    yield return new WaitForSeconds(2);
                }
            }

            if (end)
            {
                break;
            }
        }
    }

    public void AddScore(int value)
    {
        score+=value;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString(); 
    }

    public void GameOver()
    {
        Endtext.text = "Game Over!";
        end = true;
        RestartText.text = "Press R to restart";
        restart = true;
    }
}
