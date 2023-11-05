using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� 1 �ڷΰ��� �ӵ� ���� ����
// ���� 2 �ڷΰ��� ��� ����
// ���� 3 �������� Ƣ�����
// �ð�����

public class EnemyGray2 : MonoBehaviour
{
    private float moveDir = -1f; //�̵����� �ٲٱ� ����
    private float randomTime;
    float enemyLifeTime = 12f; // ���� ���� (���� �ð�)
    [SerializeField]
    private float MoveSpeed;

    //private float BackSpeed;

    private void Awake()
    {
        moveDir = -1;
        randomTime = Random.Range(0.5f, 1f) + 4f; //ù ���� 2�� ����, ���� �ð� �ּ�, �ִ�
        //BackSpeed = MoveSpeed;
    }

    private void Update()
    {
        randomTime -= Time.deltaTime;
        enemyLifeTime -= Time.deltaTime;
        if (enemyLifeTime < 0f)
        {
            Destroy(this.gameObject);
        }

        if (randomTime < 0f)
        {
            MoveSpeed = MoveSpeed / 2;
            randomTime = Random.Range(0.5f, 1f);
            moveDir *= -1f; //  ������ ������ ������ȯ
            MoveSpeed = MoveSpeed * 2;
            //MoveSpeed = BackSpeed;
        }
        transform.position += new Vector3(moveDir * Time.deltaTime * MoveSpeed, 0f, 0f);    // �����̵�
    }
}
