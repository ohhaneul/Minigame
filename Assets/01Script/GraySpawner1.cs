using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraySpawner1 : MonoBehaviour
{
    EnemyGray2 Trans;
    [SerializeField]
    private GameObject prefab;
    private Vector2 GraySpawnPos;

    private void Awake()
    {
        //Debug.Log("ȸ������� �⵿�غ�");
        StartCoroutine("SpawnGray");
        GraySpawnPos = new Vector2(10, -4);
    }


    IEnumerator SpawnGray()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);    //�� ���� ����
            GameObject Gray = Instantiate(prefab, GraySpawnPos, Quaternion.identity);
            Debug.Log("�������");
            Debug.Log(GraySpawnPos);
        }
    }
}
