using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ĳ���� �������� ����

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 20f)] float speed;
    [SerializeField]
    float posValue;     //������ �ٳ�;� ó������ ���ƿ���?

    //private Vector2 startPos;
    float newPos;

    //private void Awake()
    //{
    //    startPos = transform.position;
    //    // startPos = new Vector2(4.85f, -4f); �̷��Ե� �ǰ�
    //}

    //private void Update()
    //{
    //    newPos = Mathf.Repeat(Time.time * speed, posValue);
    //    transform.position = startPos + Vector2.left * newPos;
    //}

    private Vector2 startPos = new Vector2(4.85f, -4f);
    private void Update()
    {
        transform.position += (Vector3.left * Time.deltaTime * speed);

        if (transform.position.x <= -4)
                transform.position = startPos;
    }


    // �� ĳ�������� ������ ~
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name.Equals("MyCat"))
    //    {
    //        ReturnToStartPos();
    //        Debug.Log("------------------------------");
    //    }
    //}
    //private void ReturnToStartPos()
    //{
    //    transform.position = new Vector3(0,0.0f, 0.0f);   // �����ʱ���ġ �߸ŷ� �ٲ㺸����
    //    Debug.Log("---------return�Լ� ȣ�� �Ϸ�---------");

    //}

}
