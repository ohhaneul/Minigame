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
            Debug.Log("아야!!!!!!!!!!!!!!!!!!!!!!!!!");
            SetGameOverUI();
        }
    }


    public void SetGameOverUI()
    {
        Debug.Log("호출돼써용");
        LeanTween.moveLocalY(UI, -50f, 0.5f)   //y축 좌표를 저만큼 0.5초 동안 위로 이동 
            .setDelay(0.5f)
            .setEase(LeanTweenType.easeInOutCubic)
            .setIgnoreTimeScale(true); //부드럽게
    }


}
