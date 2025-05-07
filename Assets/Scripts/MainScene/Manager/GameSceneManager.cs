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
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϴ� �ν��Ͻ��� ����
        }
    }

    public void LoadScene(SceneType type)
    {
        if (sceneDictionary.TryGetValue(type, out string sceneName))
        {
            SceneManager.LoadScene(sceneName);  // �� ��ȯ
        }
        else
        {
            Debug.LogError($"�� ��ȯ ���� : {type} �� ��ϵ��� ���� ���Դϴ�.");
        }
    }

    //public void LoadSceneWithTitle(SceneType type)
    //{
    //    if (titleUIInstance == null) // ���� �ν��Ͻ��� ���ٸ� ����
    //    {
    //        titleUIInstance = Instantiate(titleUIPrefab);
    //        DontDestroyOnLoad(titleUIInstance); // �� �Ѿ�� ����
    //    }

    //    titleUIInstance.SetActive(true); // Ÿ��Ʋ UI ���̱�

    //    StartCoroutine(WaitForStartGameButton(type)); // ��ư ���� ������ ���
}

    //public void LoadScene(SceneType type) // ���� SceneType�� ���� ��ȯ�ϴ� �޼���
    //{
    //    if (sceneDictionary.TryGetValue(type, out string sceneName)) // ��ųʸ����� �� �̸��� ã�´�
    //    {
    //        SceneManager.LoadScene(sceneName);
    //    }
    //    else
    //    {
    //        Debug.LogError($"�� ��ȯ ���� : {type} �� ��ϵ��� ���� ���Դϴ�.");
    //    }

    //    if (titleUI != null)
    //    {
    //        titleUI.SetActive(true);  // Ÿ��Ʋ UI ���̱�
    //    }

    //    StartCoroutine(WaitForStartGameButton(type)); // Ÿ��Ʋ UI���� ���� ���� ��ư�� ������ �� ���� ��ȯ�ϵ��� ó��
    //}

    //private IEnumerator WaitForStartGameButton(SceneType type)
    //{
    //    while (titleUIInstance != null && titleUIInstance.activeSelf)
    //    {
    //        yield return null; // Ÿ��Ʋ UI�� �����ִ� ���� ���
    //    }

    //    if (sceneDictionary.TryGetValue(type, out string sceneName))
    //    {
    //        SceneManager.LoadScene(sceneName); // Ÿ��Ʋ UI ������� �� �ε�
    //    }
    //    else
    //    {
    //        Debug.LogError($"�� ��ȯ ����: {type}�� ��ϵ��� ���� ���Դϴ�.");
    //    }
    //}


    //private IEnumerator WaitForStartGameButton(SceneType type)
    //{
    //    while (titleUI.activeSelf)
    //    {
    //        yield return null; // Ÿ��Ʋ UI�� Ȱ��ȭ �Ǿ� �ִ� ���� ���
    //    }

    //    SceneManager.LoadScene(sceneDictionary[type]); // Ÿ��Ʋ UI�� ������� �ش� ���� �ε�
    //}

    public enum SceneType // �� Ÿ���� �����ϴ� ������. �� ���� ���� ������ �� �ֵ��� ����
    {
        MainScene,
        FlappyPlane,
        TheStack
    }
}
