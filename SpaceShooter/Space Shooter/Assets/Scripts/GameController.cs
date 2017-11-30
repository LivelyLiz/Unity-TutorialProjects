using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text ScoreText;
    public Text GameOverText;
    public Text RestartText;
    public Vector3 SpawnValue;
    public float SpawnWait;
    public float StarWait;
    public float WaveWait;
    public int HazardCount;
    public GameObject Hazard;

    private int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        gameOver = false;
        restart = false;

        RestartText.text = "";
        GameOverText.text = "";
    }

    void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        GameOverText.text = "GAME OVER";
        gameOver = true;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StarWait);

        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-SpawnValue.x, SpawnValue.x), SpawnValue.y, SpawnValue.z + Random.Range(i, 10));
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(Hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(SpawnWait);
            }

            yield return new WaitForSeconds(WaveWait);

            if (gameOver)
            {
                restart = true;
                RestartText.text = "Press R for Restart";
                break;
            }
        }   
    }
}
