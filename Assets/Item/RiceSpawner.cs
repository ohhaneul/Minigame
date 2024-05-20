using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;

    private void Awake()
    {
        StartCoroutine("SpawnRice");
    }


    IEnumerator SpawnRice()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f);    //�� ���� ����
            Debug.Log("����");
            Vector2 position = new Vector2(transform.position.x,
                                    Random.Range(2f, 3.5f)); // (����)��������Ʈ�κ��� ���̸� ����

            GameObject Rice = Instantiate(prefab, position, Quaternion.identity);
        }
    }

}
