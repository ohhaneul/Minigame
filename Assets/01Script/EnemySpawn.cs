using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 리스폰좀 제발

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 20f)] float speed;   // 걍 스크롤로 스피드 하는거 해보고 싶었으 ㅋ
    [SerializeField]
    float posValue;     //어디까지 다녀와야 처음으로 돌아오실?

    Vector2 startPos;
    float newPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {

        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.left * newPos;
    }


    // 내 캐릭터한테 닿으면 ~
    // 왜안되지왜안되지왜안되지왜안되지왜안되지왜안되지왜안되지왜안되지왜안되지왜안되지
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("MyCat"))
        {
            ReturnToStartPos();
            Debug.Log("------------------------------");
        }
    }
    private void ReturnToStartPos()
    {
        transform.position = new Vector3(4.85f, -4.0f, 0.0f);   // ㅎㅎ초기위치 야매로 바꿔보리깅
        Debug.Log("---------return함수 호출 완료---------");
    }

}
