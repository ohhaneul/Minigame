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

    float spawnInterval = 3f; // �� ���� ����
    float enemyLifeTime = 6f; // ���� ���� (���� �ð�)


    private float BlackCatTimer = 0f;
    private bool fx = true;

    void Update()
    {
        BlackCatTimer += Time.deltaTime;

        if (BlackCatTimer >= spawnInterval && fx )
        {
            SpawnEnemy();
            BlackCatTimer = 0f;
            fx = false;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = spawnPoint.position;
        float speed = Random.Range(minSpeed, maxSpeed);

        // �� ������Ʈ ����
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("�����P��", enemy);
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
