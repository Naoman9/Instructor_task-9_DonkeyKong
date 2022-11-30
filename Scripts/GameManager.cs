using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;

    public float startTime = 2.0f;
    public float delayTime = 5.0f;
    public float speed = 5.0f;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startTime, delayTime);

        isGameActive = true;
        score = 0;

        UpdateScore(0);
    }

    // Score Updating
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Enemy Spawning
    void SpawnEnemies()
    {
        Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
    }

    // Check Game Over
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart Button
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
