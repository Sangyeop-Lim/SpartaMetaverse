using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class LadderTrigger : MonoBehaviour
{
    [SerializeField] private SceneType targetScene;
    [SerializeField] private GameObject interactionUI;

    private bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("미니게임 시작");
            GameSceneManager.Instance.LoadScene(targetScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("플레이어가 범위에 들어옴");
            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("플레이어가 범위에서 나감");
            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }
}
