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
        //Debug.Log("회색고양이 출동준비");
        StartCoroutine("SpawnGray");
        GraySpawnPos = new Vector2(10, -4);
    }


    IEnumerator SpawnGray()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);    //템 생성 간격
            GameObject Gray = Instantiate(prefab, GraySpawnPos, Quaternion.identity);
            Debug.Log("모찌나가요");
            Debug.Log(GraySpawnPos);
        }
    }
}
