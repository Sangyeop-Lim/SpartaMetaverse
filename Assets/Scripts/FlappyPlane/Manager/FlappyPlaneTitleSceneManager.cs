using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlappyPlaneTitleSceneManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene("FlappyPlane"); // FlappyPlane ������ �Ѿ��, Ÿ��Ʋ ���� ����
    }

    private void OnExitButtonClicked()
    {        
        Application.Quit();
    }
}
