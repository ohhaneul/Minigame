using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//안쓰는 코드
// 코루틴 공부하기

public class ItemBread : MonoBehaviour
{
    //BreadSpawner BreadSpawner;
    public GameObject ItemPrefab; // 생성할 아이템 프리팹
    public Transform spawnPoint; // 아이템 생성 위치

    [SerializeField]
    float MoveSpeed; // 아이템이 날아오는 속도

    //private float spawnInterval = 2f; // 템 생성 간격 이거 말고 브레드 스포너에 
    private float ItemLifeTime = 5f; // 적의 수명 (삭제 시간)

    Rigidbody2D bread;

    private void Awake()
    {
        Debug.Log("아이템함수 시작 ");
        bread = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(3); // 게임 시작 n초 후부터인데 왜 적용이 안되지
        Debug.Log("아이템 생성 ");
        while (true)
        {
            SpawnBread();   // 아이템 1번 빵
            bread.velocity = new Vector2(-MoveSpeed, 0f);
            //yield return new WaitForSeconds(spawnInterval); // 스폰 텀(브레드 스포너로 이동)
        }
    }

    void SpawnBread()
    {
        Vector2 position = new Vector2(spawnPoint.position.x,
                                            Random.Range(-2f, 3.3f)); // 스폰포인트로부터 높이만 변경
        GameObject Bread = Instantiate(ItemPrefab, position, Quaternion.identity);
        Destroy(Bread, ItemLifeTime);
        Debug.Log("아이템생성 ");
    }


    // 캐릭터한테 닿으면 ~
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("음식에 닿음");
            Destroy(this.gameObject);
        }
    }

}
