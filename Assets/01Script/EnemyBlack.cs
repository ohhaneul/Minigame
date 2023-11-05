using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlack : MonoBehaviour
{
    public GameObject enemyPrefab; // 생성할 적의 프리팹
    public Transform spawnPoint; // 적의 생성 위치


    [SerializeField]
    float minSpeed; // 최소 이동 속도
    [SerializeField]
    float maxSpeed; // 최대 이동 속도

    float spawnInterval = 3f; // 적 생성 간격
    float enemyLifeTime = 6f; // 적의 수명 (삭제 시간)


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

        // 적 오브젝트 생성
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("생성핻다", enemy);
        // 적 오브젝트에 Rigidbody2D를 가지고 있어야 이동
        Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();

        if (enemyRigidbody != null)
        {
            // 오른쪽에서 왼쪽 방향으로 이동하도록 설정
            enemyRigidbody.velocity = new Vector2(-speed, 0);
        }

        Destroy(enemy, enemyLifeTime);
    }


}
