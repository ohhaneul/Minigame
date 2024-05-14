using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;

    private void Awake()
    {
        SetGameOverUI();
    }
    public void SetGameOverUI()
    {

        LeanTween.moveLocalY(UI, -50f, 0.5f)   //y�� ��ǥ�� ����ŭ 0.5�� ���� ���� �̵� 
            .setDelay(0.5f)
            .setEase(LeanTweenType.easeInOutCubic); //�ε巴��
    }


}
