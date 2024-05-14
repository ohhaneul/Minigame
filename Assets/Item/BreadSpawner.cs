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
            yield return new WaitForSeconds(1f);    //�� ���� ����

            Vector2 position = new Vector2(transform.position.x,
                                    Random.Range(-2f, 3.3f)); // ��������Ʈ�κ��� ���̸� ����

            GameObject Bread = Instantiate(prefab, position, Quaternion.identity);
            //Debug.Log("�����ʿ��� ");
        }
    }

}
