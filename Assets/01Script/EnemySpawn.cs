using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField]
    [Range(1f, 20f)] float speed;
    [SerializeField]
    float posValue;

    Vector2 startPos;
    float newPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.left * newPos;
    }


    //ĳ�������� ������ ~
    // ������ �׳� ���ӿ����� �س��µ� ���߿� ���� ��� �߰��ؼ� �����ϴ�!
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name.Equals("MyCat"))
    //    {
    //        Time.timeScale = 0f;
    //    }
    //}

}
