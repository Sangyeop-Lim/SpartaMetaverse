using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }

    private Dictionary<SceneType, string> sceneDictionary = new Dictionary<SceneType, string>()
    {
        { SceneType.MainScene, "MainScene" },
        { SceneType.FlappyPlane, "FlappyPlane" },
        { SceneType.TheStack, "TheStack" }
    };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(SceneType type) // ���� SceneType�� ���� ��ȯ�ϴ� �޼���
    {
        if (sceneDictionary.TryGetValue(type, out string sceneName)) // ��ųʸ����� �� �̸��� ã�´�
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"�� ��ȯ ���� : {type} �� ��ϵ��� ���� ���Դϴ�.");
        }
    }

    public enum SceneType // �� Ÿ���� �����ϴ� ������. �� ���� ���� ������ �� �ֵ��� ����
    {
        MainScene,
        FlappyPlane,
        TheStack
    }
}
