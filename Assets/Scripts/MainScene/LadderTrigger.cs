using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class LadderTrigger : MonoBehaviour
{
    [SerializeField] private SceneType targetScene; // ��ȯ�� �� Ÿ���� �����ϱ� ���� ����
    [SerializeField] private GameObject interactionUI; // EŰ�� ������ �� ǥ�õ� UI

    private bool isPlayerInRange = false; // �÷��̾ ���� �ȿ� �ִ��� ���θ� �Ǵ��ϴ� ����

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("�̴ϰ��� ����");
            GameSceneManager.Instance.LoadSceneWithTitle(targetScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // �÷��̾ Ʈ���� ������ ������ �� ȣ��Ǵ� �޼���
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("�÷��̾ ������ ����");
            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) // �÷��̾ Ʈ���� �������� ������ �� ȣ��Ǵ� �޼���
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
