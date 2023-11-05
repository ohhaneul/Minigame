using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 코루틴 공부하기

public class ItemBread : MonoBehaviour
{
    public GameObject ItemPrefab; // 생성할 아이템 프리팹
    public Transform spawnPoint; // 아이템 생성 위치

    [SerializeField]
    float MoveSpeed; // 아이템이 날아오는 속도

    private float spawnInterval = 2f; // 템 생성 간격
    private float ItemLifeTime = 5f; // 적의 수명 (삭제 시간)

    Rigidbody2D bread;

    private void Awake()
    {
        bread = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(3); // 게임 시작 n초 후부터

        while (true)
        {
            SpawnBread();   // 아이템 1번 빵
            bread.velocity = new Vector2(-MoveSpeed, 0f);
            yield return new WaitForSeconds(spawnInterval); // 스폰 텀
        }
    }

    void SpawnBread()
    {
        Vector2 position = new Vector2(spawnPoint.position.x,
                                            Random.Range(-2f, 3.3f)); // 스폰포인트로부터 높이만 변경
        GameObject Bread = Instantiate(ItemPrefab, position, Quaternion.identity);
        Destroy(Bread, ItemLifeTime);
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
