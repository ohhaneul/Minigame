using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ڷ�ƾ �����ϱ�

public class ItemBread : MonoBehaviour
{
    public GameObject ItemPrefab; // ������ ������ ������
    public Transform spawnPoint; // ������ ���� ��ġ

    [SerializeField]
    float MoveSpeed; // �������� ���ƿ��� �ӵ�

    private float spawnInterval = 2f; // �� ���� ����
    private float ItemLifeTime = 5f; // ���� ���� (���� �ð�)

    Rigidbody2D bread;

    private void Awake()
    {
        bread = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(3); // ���� ���� n�� �ĺ���

        while (true)
        {
            SpawnBread();   // ������ 1�� ��
            bread.velocity = new Vector2(-MoveSpeed, 0f);
            yield return new WaitForSeconds(spawnInterval); // ���� ��
        }
    }

    void SpawnBread()
    {
        Vector2 position = new Vector2(spawnPoint.position.x,
                                            Random.Range(-2f, 3.3f)); // ��������Ʈ�κ��� ���̸� ����
        GameObject Bread = Instantiate(ItemPrefab, position, Quaternion.identity);
        Destroy(Bread, ItemLifeTime);
    }


    // ĳ�������� ������ ~
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("���Ŀ� ����");
            Destroy(this.gameObject);
        }
    }

}
