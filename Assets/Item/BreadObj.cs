using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadObj : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float MoveSpeed; // �������� ���ƿ��� �ӵ�
    private Vector3 moveDir; //�̵����� 

    private float ItemLifeTime = 5f; // ���� ���� (���� �ð�) ->  ȭ������� ������ ���������� �ϴ°� �� ����

    private void Awake()
    {
        moveDir = new Vector3(-1f, 0f, 0f);
        ItemLifeTime += Time.time;
        
    }

    private void Update()
    {
        if (ItemLifeTime < Time.time) 
            Destroy(this.gameObject);

        transform.position += moveDir * Time.deltaTime * MoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("���Ŀ� ����");
            Destroy(this.gameObject);   
                                        
        }
    }


}
