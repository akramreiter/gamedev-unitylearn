using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private bool gameOver = false;
    private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Menu Screen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //UpdateScore(5);
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
    }

    public void SetGameOverState()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        gameOver = false;
        score = 0;
        StartGame();
    }

    public void StartGame()
    {
        menu.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        scoreText.text = "Score: " + score;
    }

    public void AdjustSpawnRate(float divide)
    {
        spawnRate /= divide;
    }
}
