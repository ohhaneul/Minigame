using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;
    [SerializeField]
    public float JumpPower;
    public bool isJump = false;
    GameObject player;

    int count = 0;

    void Start()
{
    this.player = GameObject.FindGameObjectWithTag("Player");
}


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (count < 4)
            {
                rigid.gravityScale = 2;
                isJump = true;
                rigid.velocity = Vector2.zero;  // 점프 속도 유지
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                count++;
            }

            else
                isJump = false;

        }
    }

    //이거는 Collision일때
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.name.Equals("Ground")) // 땅
    //    {
    //        isJump = false;
    //        count = 0;
    //    }
    //}

    // is Trigger 체크 했을때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Ground"))
        {
            isJump = false;
            count = 0;
            rigid.gravityScale = 0f;
            rigid.velocity = Vector2.zero;
        }

        // "Enemy" 태그를 가진 오브젝트와 충돌 여부를 확인
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float questionY = Mathf.Abs(transform.position.y - collision.transform.position.y);
            float questionX = Mathf.Abs(transform.position.x - collision.transform.position.x);


            if (0.4f < questionY && questionY < 0.5f && questionX <= 0.5f)
            {
                live(collision.gameObject);
            }
            else
            {
                Die(collision.gameObject);

            }

        }
    }

    void Die(GameObject enemy)
    {
        Time.timeScale = 0f;
        Debug.Log("교통사고 : " + enemy.name);
    }
    void live(GameObject enemy)
    {
        rigid.gravityScale = 2;
        rigid.velocity = Vector2.zero;  
        rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        Debug.Log("머리 밟고 점프 : " + enemy.name);
    }


}

