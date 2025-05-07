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

    [SerializeField] private GameObject titleUIPrefab;
    private GameObject titleUIInstance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 인스턴스는 제거
        }
    }

    public void LoadScene(SceneType type)
    {
        if (sceneDictionary.TryGetValue(type, out string sceneName))
        {
            SceneManager.LoadScene(sceneName);  // 씬 전환
        }
        else
        {
            Debug.LogError($"씬 전환 실패 : {type} 은 등록되지 않은 씬입니다.");
        }
    }

    //public void LoadSceneWithTitle(SceneType type)
    //{
    //    if (titleUIInstance == null) // 아직 인스턴스가 없다면 생성
    //    {
    //        titleUIInstance = Instantiate(titleUIPrefab);
    //        DontDestroyOnLoad(titleUIInstance); // 씬 넘어가도 유지
    //    }

    //    titleUIInstance.SetActive(true); // 타이틀 UI 보이기

    //    StartCoroutine(WaitForStartGameButton(type)); // 버튼 누를 때까지 대기
}

    //public void LoadScene(SceneType type) // 씬을 SceneType에 따라 전환하는 메서드
    //{
    //    if (sceneDictionary.TryGetValue(type, out string sceneName)) // 딕셔너리에서 씬 이름을 찾는다
    //    {
    //        SceneManager.LoadScene(sceneName);
    //    }
    //    else
    //    {
    //        Debug.LogError($"씬 전환 실패 : {type} 은 등록되지 않은 씬입니다.");
    //    }

    //    if (titleUI != null)
    //    {
    //        titleUI.SetActive(true);  // 타이틀 UI 보이기
    //    }

    //    StartCoroutine(WaitForStartGameButton(type)); // 타이틀 UI에서 게임 시작 버튼을 눌렀을 때 씬을 전환하도록 처리
    //}

    //private IEnumerator WaitForStartGameButton(SceneType type)
    //{
    //    while (titleUIInstance != null && titleUIInstance.activeSelf)
    //    {
    //        yield return null; // 타이틀 UI가 켜져있는 동안 대기
    //    }

    //    if (sceneDictionary.TryGetValue(type, out string sceneName))
    //    {
    //        SceneManager.LoadScene(sceneName); // 타이틀 UI 사라지면 씬 로드
    //    }
    //    else
    //    {
    //        Debug.LogError($"씬 전환 실패: {type}은 등록되지 않은 씬입니다.");
    //    }
    //}


    //private IEnumerator WaitForStartGameButton(SceneType type)
    //{
    //    while (titleUI.activeSelf)
    //    {
    //        yield return null; // 타이틀 UI가 활성화 되어 있는 동안 대기
    //    }

    //    SceneManager.LoadScene(sceneDictionary[type]); // 타이틀 UI가 사라지면 해당 씬을 로드
    //}

    public enum SceneType // 씬 타입을 정의하는 열거형. 각 씬을 쉽게 관리할 수 있도록 정의
    {
        MainScene,
        FlappyPlane,
        TheStack
    }
}
