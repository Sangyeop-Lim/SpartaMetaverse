using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;
    private int bestScore = 0;

    private const string BestScoreKey = "BestScore";

    [SerializeField] private GameObject resultPanel;

    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        uiManager.UpdateBestScore(bestScore);

        if (resultPanel != null)
            resultPanel.SetActive(false);
    }


    public void GameOver()
    {
        Debug.Log("Game Over");

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
            uiManager.UpdateBestScore(bestScore);
            Debug.Log("최고 점수 갱신: " + bestScore);
        }

        if (resultPanel != null)
            resultPanel.SetActive(true);

        uiManager.ShowResult(currentScore, bestScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"[AddScore] Called. +{score}, Total: {currentScore}");
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }
}
