using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 문제 1 뒤로가기 속도 왤케 빠름
// 문제 2 뒤로가기 모션 설정
// 문제 3 여러마리 튀어나오게
// 시간설정

public class EnemyGray2 : MonoBehaviour
{
    private float moveDir = -1f; //이동방향 바꾸기 위해
    private float randomTime;
    float enemyLifeTime = 12f; // 적의 수명 (삭제 시간)
    [SerializeField]
    private float MoveSpeed;

    //private float BackSpeed;

    private void Awake()
    {
        moveDir = -1;
        randomTime = Random.Range(0.5f, 1f) + 4f; //첫 등장 2초 유지, 랜덤 시간 최소, 최대
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
            moveDir *= -1f; //  음수의 곱으로 방향전환
            MoveSpeed = MoveSpeed * 2;
            //MoveSpeed = BackSpeed;
        }
        transform.position += new Vector3(moveDir * Time.deltaTime * MoveSpeed, 0f, 0f);    // 실제이동
    }
}
