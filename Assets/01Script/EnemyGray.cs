using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̰� �����ֳ� 2Ʈ

public class EnemyGray : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ ���� ������
    public Transform spawnPoint; // ���� ���� ��ġ

    // ����
    float spawnInterval = 2f; // �� ���� ����
    float enemyLifeTime = 10f; // ���� ���� (���� �ð�)

    private float GrayCatTimer = 0f;// �� ���� �ð�
    private float moveTimer = 3f;   // ������ �ٲٴ� ����
    private bool MoveLeft = true;
    private float speed = 3;

    void Update()
    {
        GrayCatTimer += Time.deltaTime;

        if (GrayCatTimer >= spawnInterval && MoveLeft)
        {
            SpawnEnemy();
            GrayCatTimer = 0f;
            MoveLeft = false;
        }


    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = spawnPoint.position;

        // �� ������Ʈ ����
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();

        if (enemyRigidbody != null)
        {
            if (GrayCatTimer > moveTimer)
            {
                
                enemyRigidbody.velocity = new Vector2(-speed, 0); // ���� �������� �̵�

            }
            else
            {
                enemyRigidbody.velocity = new Vector2(-speed, 0); // �ݴ� �������� �̵�
            }
        }

        Destroy(enemy, enemyLifeTime);
    }
}
