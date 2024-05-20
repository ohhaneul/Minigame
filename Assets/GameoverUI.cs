using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("�ƾ�!!!!!!!!!!!!!!!!!!!!!!!!!");
            SetGameOverUI();
        }
    }


    public void SetGameOverUI()
    {
        Debug.Log("ȣ��Ž��");
        LeanTween.moveLocalY(UI, -50f, 0.5f)   //y�� ��ǥ�� ����ŭ 0.5�� ���� ���� �̵� 
            .setDelay(0.5f)
            .setEase(LeanTweenType.easeInOutCubic)
            .setIgnoreTimeScale(true); //�ε巴��
    }


}
