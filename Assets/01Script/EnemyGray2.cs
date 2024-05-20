using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� 1 �ڷΰ��� �ӵ� ���� ���� (�ذ�!)
// ���� 2 �ڷΰ��� ��� ���� (�ذ�!!)
// ���� 3 �������� Ƣ����� (�ذ�!!)
// �ð����� 
// �״ϱ� �̰�.. awake ���� ������ 3000�� �̻��� �� ����ǵ��� �ϰ����

public class EnemyGray2 : MonoBehaviour
{

    public GameObject enemyPrefab; // ������ ���� ������
    //public Transform spawnPoint; // ���� ���� ��ġ(SpawnPoint�ο�)

    private float moveDir = -1f; //�̵����� �ٲٱ� ����
    private float randomTime;
    [SerializeField]
    private float MoveSpeed; //�ʱ� �̵� �ӵ� ������
    float moveMaxX;
    private SpriteRenderer sr;

    //private float BackSpeed;
    private int turnCounter;

    private void Awake()
    {

        moveDir = -1;
        randomTime = Random.Range(0.5f, 1f) +2; // ���� �ð� �ּ�, �ִ� (+2�� ������Ϸ��� ����)
        TryGetComponent<SpriteRenderer>(out sr);
        //BackSpeed = MoveSpeed;
        moveMaxX  = -1f + Random.Range(-0.3f, 0.3f); //�Դ� ���� �ϴ� �Ÿ�
        turnCounter = 4; //������ �ٲٴ� �ִ� Ƚ�� (¦���� �ؾ� ���������� �������� ����!)
    }



    private void Update()
    {

        if (turnCounter > 0)
        { 
            if (moveMaxX > transform.position.x && moveDir < 0f)
            {
                moveMaxX = 1.5f;
                moveDir = 1f;   
                sr.flipX = true;
                MoveSpeed = 2f; //�����ӵ�
                turnCounter--;
            }
            if (moveMaxX < transform.position.x && moveDir > 0f)
            {
                moveMaxX = -1f + Random.Range(-0.3f, 0.3f);
                moveDir = -1f;  
                sr.flipX = false;
                MoveSpeed = 3f; // ���ѵ� �����ӵ� ( SerializeField ���̶� �Ȱ��� ������!)
                turnCounter--;
            }
        }

        if(transform.position.x < -4f)  //ȭ�� ������ (��ǥ ���� ����) ������ ����
        {
            Destroy(gameObject);
        }
            transform.position += new Vector3(moveDir * Time.deltaTime * MoveSpeed, 0f, 0f);    // �����̵�
    }
}
