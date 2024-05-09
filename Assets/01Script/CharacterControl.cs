using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("참조 확인" + scoreController.gameObject.name);

        jumpScript = GameObject.Find("JumpChance").GetComponent<JumpCount>();

    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            Jump();
        }
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        RestartGame(); // 시간이 멈춰있을 때 스페이스바를 누르면 게임을 재시작
        //    }
        //}
    }

    public void Jump()  //점프
    {
        if (Input.GetKeyDown(KeyCode.Space))    
        {

            if (count < 4)
            {
                rigid.gravityScale = 2;
                isJump = true;
                rigid.velocity = Vector2.zero;  // 점프 속도 유지
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                JumpCounter++;
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
            JumpCounter = 0;
            rigid.gravityScale = 0f;
            rigid.velocity = Vector2.zero;
        }

        // "Enemy" 태그를 가진 오브젝트와 충돌 여부를 확인
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float questionY = Mathf.Abs(transform.position.y - collision.transform.position.y);
            float questionX = Mathf.Abs(transform.position.x - collision.transform.position.x);


            if (0.4f < questionY && questionY < 0.7f && questionX <= 0.7f)
            {
                live(collision.gameObject);
                scoreController.Score_300();
                scoreController2.Score_300();
                Debug.Log("머리 밟기 +300점");
            }
            else
            {
                Die(collision.gameObject);

            }

        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("아이템 +300점");
            scoreController.Score_300();
            scoreController2.Score_300();
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
    //리게임
    //void RestartGame()
    //{
    //    Time.timeScale = 1f; //게임재개
    //    ResetObjects();
    //    Scene currentScene = SceneManager.GetActiveScene();
    //    SceneManager.LoadScene(currentScene.name);
    //}

    //// 모든 오브젝트들을 초기 위치로 되돌리는 함수
    //void ResetObjects()
    //{
    //    // "Resettable" 스크립트가 있는 모든 오브젝트들을 찾아 초기화합니다.
    //    Resettable[] resettables = FindObjectsOfType<Resettable>();
    //    foreach (Resettable resettable in resettables)
    //    {
    //        resettable.Reset(); // Resettable 스크립트의 Reset 함수 호출
    //    }
    //}

}

