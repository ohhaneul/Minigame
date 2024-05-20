using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이거 쓸수있나 2트

public class EnemyGray : MonoBehaviour
{
    public GameObject enemyPrefab; // 생성할 적의 프리팹
    public Transform spawnPoint; // 적의 생성 위치

    // 설정
    float spawnInterval = 2f; // 적 생성 간격
    float enemyLifeTime = 10f; // 적의 수명 (삭제 시간)

    private float GrayCatTimer = 0f;// 적 기준 시간
    private float moveTimer = 3f;   // 방향을 바꾸는 간격
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

        // 적 오브젝트 생성
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();

        if (enemyRigidbody != null)
        {
            if (GrayCatTimer > moveTimer)
            {
                
                enemyRigidbody.velocity = new Vector2(-speed, 0); // 원래 방향으로 이동

            }
            else
            {
                enemyRigidbody.velocity = new Vector2(-speed, 0); // 반대 방향으로 이동
            }
        }

        Destroy(enemy, enemyLifeTime);
    }
}
