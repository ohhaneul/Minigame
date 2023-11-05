using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadObj : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float MoveSpeed; // 아이템이 날아오는 속도
    private Vector3 moveDir; //이동방향 

    private float ItemLifeTime = 5f; // 적의 수명 (삭제 시간) ->  화면밖으로 나가면 없어지도록 하는게 더 좋음

    private void Awake()
    {
        moveDir = new Vector3(-1f, 0f, 0f);
        ItemLifeTime += Time.time;
        
    }

    private void Update()
    {
        if (ItemLifeTime < Time.time) 
            Destroy(this.gameObject);

        transform.position += moveDir * Time.deltaTime * MoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("음식에 닿음");
            Destroy(this.gameObject);   
                                        
        }
    }


}
