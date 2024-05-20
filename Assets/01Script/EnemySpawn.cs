using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 리스폰좀 제발

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 20f)] float speed;
    [SerializeField]
    float posValue;     //어디까지 다녀와야 처음으로 돌아오실?

    //private Vector2 startPos;
    float newPos;

    //private void Awake()
    //{
    //    startPos = transform.position;
    //    // startPos = new Vector2(4.85f, -4f); 이렇게도 되고
    //}

    //private void Update()
    //{
    //    newPos = Mathf.Repeat(Time.time * speed, posValue);
    //    transform.position = startPos + Vector2.left * newPos;
    //}

    private Vector2 startPos = new Vector2(4.85f, -4f);
    private void Update()
    {
        transform.position += (Vector3.left * Time.deltaTime * speed);

        if (transform.position.x <= -4)
                transform.position = startPos;
    }


    // 내 캐릭터한테 닿으면 ~
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name.Equals("MyCat"))
    //    {
    //        ReturnToStartPos();
    //        Debug.Log("------------------------------");
    //    }
    //}
    //private void ReturnToStartPos()
    //{
    //    transform.position = new Vector3(0,0.0f, 0.0f);   // ㅎㅎ초기위치 야매로 바꿔보리깅
    //    Debug.Log("---------return함수 호출 완료---------");

    //}

}
