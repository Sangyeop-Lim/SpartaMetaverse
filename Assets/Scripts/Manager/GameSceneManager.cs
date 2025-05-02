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

    public void LoadScene(SceneType type) // 씬을 SceneType에 따라 전환하는 메서드
    {
        if (sceneDictionary.TryGetValue(type, out string sceneName)) // 딕셔너리에서 씬 이름을 찾는다
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"씬 전환 실패 : {type} 은 등록되지 않은 씬입니다.");
        }
    }

    public enum SceneType // 씬 타입을 정의하는 열거형. 각 씬을 쉽게 관리할 수 있도록 정의
    {
        MainScene,
        FlappyPlane,
        TheStack
    }
}
