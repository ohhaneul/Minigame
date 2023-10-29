using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlack : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ ���� ������
    public Transform spawnPoint; // ���� ���� ��ġ

    [SerializeField]
    float minSpeed; // �ּ� �̵� �ӵ�
    [SerializeField]
    float maxSpeed; // �ִ� �̵� �ӵ�

    float spawnInterval = 4f; // �� ���� ����
    float enemyLifeTime = 7f; // ���� ���� (���� �ð�)

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = spawnPoint.position;
        float speed = Random.Range(minSpeed, maxSpeed);

        // �� ������Ʈ ����
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // �� ������Ʈ�� Rigidbody2D�� ������ �־�� �̵�
        Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();

        if (enemyRigidbody != null)
        {
            // �����ʿ��� ���� �������� �̵��ϵ��� ����
            enemyRigidbody.velocity = new Vector2(-speed, 0);
        }

        Destroy(enemy, enemyLifeTime);
    }
}
