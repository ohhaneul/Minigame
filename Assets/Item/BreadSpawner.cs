using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;

    private void Awake()
    {

        StartCoroutine("SpawnBread");
        
    }


    IEnumerator SpawnBread()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);    //템 생성 간격

            Vector2 position = new Vector2(transform.position.x,
                                    Random.Range(-2f, 3.3f)); // 스폰포인트로부터 높이만 변경

            GameObject Bread = Instantiate(prefab, position, Quaternion.identity);
            //Debug.Log("스포너에서 ");
        }
    }

}
