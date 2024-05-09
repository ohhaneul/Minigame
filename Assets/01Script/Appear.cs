using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Appear : MonoBehaviour
{
    public GameObject GUI; 
        
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�Ϸ����");
        if ((collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy")) ||
            (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player")))
        {
            Debug.Log("�ھҴ�");
            // Player"�� "Enemy" �±׸� ���� ������Ʈ ���� �߻��� ���
            // GameOver ������Ʈ�� Ȱ��ȭ
            GUI.SetActive(true);
            Debug.Log("�ٽ��Ҵ�");
        }
    }
}

