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

    public void LoadScene(SceneType type)
    {
        if (sceneDictionary.TryGetValue(type, out string sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"씬 전환 실패 : {type} 은 등록되지 않은 씬입니다.");
        }
    }

    public enum SceneType
    {
        MainScene,
        FlappyPlane,
        TheStack
    }
}
