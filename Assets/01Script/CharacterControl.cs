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
    ScoreController scoreController;
    ScoreController scoreController2;
    JumpCount jumpScript;
    int count = 0;
    public int JumpCounter
    {
        get => count;
        set
        {
            count = value;
            if(jumpScript != null)
            {
                jumpScript.JumpIconUpdate(4 - count);
            }
        }
    }

    void Start()
{
    this.player = GameObject.FindGameObjectWithTag("Player");
}


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        scoreController = GameObject.Find("Score").GetComponent<ScoreController>();
        scoreController2 = GameObject.Find("FinalScore").GetComponent<ScoreController>();
        Debug.Log("���� Ȯ��" + scoreController.gameObject.name);

        jumpScript = GameObject.Find("JumpChance").GetComponent<JumpCount>();

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
                rigid.velocity = Vector2.zero;  // ���� �ӵ� ����
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                JumpCounter++;
            }

            else
                isJump = false;

        }
    }

    //�̰Ŵ� Collision�϶�
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.name.Equals("Ground")) // ��
    //    {
    //        isJump = false;
    //        count = 0;
    //    }
    //}

    // is Trigger üũ ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Ground"))
        {
            isJump = false;
            JumpCounter = 0;
            rigid.gravityScale = 0f;
            rigid.velocity = Vector2.zero;
        }

        // "Enemy" �±׸� ���� ������Ʈ�� �浹 ���θ� Ȯ��
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float questionY = Mathf.Abs(transform.position.y - collision.transform.position.y);
            float questionX = Mathf.Abs(transform.position.x - collision.transform.position.x);


            if (0.4f < questionY && questionY < 0.7f && questionX <= 0.7f)
            {
                live(collision.gameObject);
                scoreController.Score_300();
                scoreController2.Score_300();
                Debug.Log("�Ӹ� ��� +300��");
            }
            else
            {
                Die(collision.gameObject);

            }

        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("������ +300��");
            scoreController.Score_300();
            scoreController2.Score_300();
        }

    }

    void Die(GameObject enemy)
    {
        Time.timeScale = 0f;
        Debug.Log("������ : " + enemy.name);
    }
    void live(GameObject enemy)
    {
        rigid.gravityScale = 2;
        rigid.velocity = Vector2.zero;  
        rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        Debug.Log("�Ӹ� ��� ���� : " + enemy.name);
    }


}

