using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Appear : MonoBehaviour
{
    public GameObject GUI; 
        
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("암레디요");
        if ((collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy")) ||
            (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player")))
        {
            Debug.Log("박았다");
            // Player"와 "Enemy" 태그를 가진 오브젝트 간에 발생할 경우
            // GameOver 오브젝트를 활성화
            GUI.SetActive(true);
            Debug.Log("다시켠다");
        }
    }
}

