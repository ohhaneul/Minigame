using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartToSample()
    {
        
        SceneManager.LoadScene("SampleScene");
        Debug.Log("����ȭ������ �Ѿ �غ� �Ϸ�");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log("����ȭ���� �ٽ� �ҷ��ȿ�");
        Time.timeScale = 1f;
    }
    public void StartToStart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("����ȭ������ �Ѿ �غ� �Ϸ�");
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("����ȭ���� �ٽ� �ҷ��ȿ�");
        Time.timeScale = 1f;
    }
}
