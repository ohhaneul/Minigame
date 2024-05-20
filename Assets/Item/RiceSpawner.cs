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
            yield return new WaitForSeconds(6f);    //템 생성 간격
            Debug.Log("ㅊㅂ");
            Vector2 position = new Vector2(transform.position.x,
                                    Random.Range(2f, 3.5f)); // (절대)스폰포인트로부터 높이만 변경

            GameObject Rice = Instantiate(prefab, position, Quaternion.identity);
        }
    }

}
