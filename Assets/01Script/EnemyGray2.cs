using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 문제 1 뒤로가기 속도 왤케 빠름 (해결!)
// 문제 2 뒤로가기 모션 설정 (해결!!)
// 문제 3 여러마리 튀어나오게
// 시간설정 
// 그니까 이걸.. awake 말고 점수가 3000점 이상일 때 실행되도록 하고싶음

public class EnemyGray2 : MonoBehaviour
{
    private float moveDir = -1f; //이동방향 바꾸기 위해
    private float randomTime;
    float enemyLifeTime = 12f; // 적의 수명 (삭제 시간)
    [SerializeField]
    private float MoveSpeed; //초기 이동 속도 지정값
    float moveMaxX;
    private SpriteRenderer sr;

    //private float BackSpeed;
    private int turnCounter;

    private void Awake()
    {

        moveDir = -1;
        randomTime = Random.Range(0.5f, 1f) +2f; // 랜덤 시간 최소, 최대 (+2는 디버깅하려고 붙임)
        TryGetComponent<SpriteRenderer>(out sr);
        //BackSpeed = MoveSpeed;
        moveMaxX  = -1f + Random.Range(-0.3f, 0.3f); //왔다 갔다 하는 거리
        turnCounter = 4; //방향을 바꾸는 최대 횟수 (짝수로 해야 정상적으로 왼쪽으로 나감!)
    }



    private void Update()
    {
        //randomTime -= Time.deltaTime;
        //enemyLifeTime -= Time.deltaTime;
        //if (enemyLifeTime < 0f)
        //{
        //    Destroy(this.gameObject);
        //}

        if (turnCounter > 0)
        { 
            if (moveMaxX > transform.position.x && moveDir < 0f)
            {
                moveMaxX = 1.5f;
                moveDir = 1f;   
                sr.flipX = true;
                MoveSpeed = 2f; //후진속도
                turnCounter--;
            }
            if (moveMaxX < transform.position.x && moveDir > 0f)
            {
                moveMaxX = -1f + Random.Range(-0.3f, 0.3f);
                moveDir = -1f;  
                sr.flipX = false;
                MoveSpeed = 3f; // 턴한뒤 전진속도 ( SerializeField 값이랑 똑같이 해줬음!)
                turnCounter--;
            }
        }

        if(transform.position.x < -4f)  //화면 밖으로 (좌표 대충 정함) 나가면 삭제
        {
            Destroy(gameObject);
        }

            //if (randomTime < 0f)
            //{
            //    //MoveSpeed = MoveSpeed / 2f;
            //    randomTime = 3f;// Random.Range(0.5f, 1f);
            //    moveDir *= -1f; //  음수의 곱으로 방향전환
            //    Debug.Log("방향전환1");
            //    if (moveDir < 0f)
            //    {
            //        Debug.Log("방향전환2");
            //        MoveSpeed = 5f;
            //        sr.flipX = false;
            //    }
            //    else
            //    {
            //        Debug.Log("방향전환3");
            //        MoveSpeed = 1f;
            //        sr.flipX = true;
            //    }
            //    //MoveSpeed = MoveSpeed * 2f;
            //    //MoveSpeed = BackSpeed;
            //}
            transform.position += new Vector3(moveDir * Time.deltaTime * MoveSpeed, 0f, 0f);    // 실제이동
    }
}
