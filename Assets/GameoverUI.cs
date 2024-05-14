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

        LeanTween.moveLocalY(UI, -50f, 0.5f)   //y축 좌표를 저만큼 0.5초 동안 위로 이동 
            .setDelay(0.5f)
            .setEase(LeanTweenType.easeInOutCubic); //부드럽게
    }


}
