using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    public TextMeshProUGUI resultScoreText;
    public TextMeshProUGUI resultBestText;

    private void Start()
    {
        restartButton.onClick.AddListener(() => GameManager.Instance.RestartGame());
        exitButton.onClick.AddListener(() => Application.Quit());
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int best)
    {
        if (bestScoreText != null)
            bestScoreText.text = "Best : " + best.ToString();
    }

    public void ShowResult(int current, int best)
    {
        if (resultScoreText != null)
            resultScoreText.text = "Score : " + current.ToString();

        if (resultBestText != null)
            resultBestText.text = "Best : " + best.ToString();
    }
}
