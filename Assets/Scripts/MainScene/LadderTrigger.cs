using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class LadderTrigger : MonoBehaviour
{
    [SerializeField] private SceneType targetScene; // 전환할 씬 타입을 설정하기 위한 변수
    [SerializeField] private GameObject interactionUI; // E키를 눌렀을 때 표시될 UI

    private bool isPlayerInRange = false; // 플레이어가 범위 안에 있는지 여부를 판단하는 변수

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("미니게임 시작");
            GameSceneManager.Instance.LoadSceneWithTitle(targetScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // 플레이어가 트리거 영역에 들어왔을 때 호출되는 메서드
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("플레이어가 범위에 들어옴");
            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) // 플레이어가 트리거 영역에서 나갔을 때 호출되는 메서드
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
