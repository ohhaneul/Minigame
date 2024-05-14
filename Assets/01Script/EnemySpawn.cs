using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ĳ���� �������� ����

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 20f)] float speed;   // �� ��ũ�ѷ� ���ǵ� �ϴ°� �غ��� �;��� ��
    [SerializeField]
    float posValue;     //������ �ٳ�;� ó������ ���ƿ���?

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


    // �� ĳ�������� ������ ~
    // �־ȵ����־ȵ����־ȵ����־ȵ����־ȵ����־ȵ����־ȵ����־ȵ����־ȵ����־ȵ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("MyCat"))
        {
            ReturnToStartPos();
            Debug.Log("------------------------------");
        }
    }
    private void ReturnToStartPos()
    {
        transform.position = new Vector3(4.85f, -4.0f, 0.0f);   // �����ʱ���ġ �߸ŷ� �ٲ㺸����
        Debug.Log("---------return�Լ� ȣ�� �Ϸ�---------");
    }

}
