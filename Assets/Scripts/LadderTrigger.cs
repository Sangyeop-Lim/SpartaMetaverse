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
            Debug.Log("�̴ϰ��� ����");
            GameSceneManager.Instance.LoadScene(targetScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("�÷��̾ ������ ����");
            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("�÷��̾ �������� ����");
            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }
}
