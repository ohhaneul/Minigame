using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartToSample()
    {
        
        SceneManager.LoadScene("SampleScene");
        Debug.Log("게임화면으로 넘어갈 준비 완료");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log("시작화면을 다시 불러옴요");
        Time.timeScale = 1f;
    }
    public void StartToStart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("시작화면으로 넘어갈 준비 완료");
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("게임화면을 다시 불러옴요");
        Time.timeScale = 1f;
    }
}
