using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Ⱦ��� �ڵ�
// �ڷ�ƾ �����ϱ�

public class ItemBread : MonoBehaviour
{
    //BreadSpawner BreadSpawner;
    public GameObject ItemPrefab; // ������ ������ ������
    public Transform spawnPoint; // ������ ���� ��ġ

    [SerializeField]
    float MoveSpeed; // �������� ���ƿ��� �ӵ�

    //private float spawnInterval = 2f; // �� ���� ���� �̰� ���� �극�� �����ʿ� 
    private float ItemLifeTime = 5f; // ���� ���� (���� �ð�)

    Rigidbody2D bread;

    private void Awake()
    {
        Debug.Log("�������Լ� ���� ");
        bread = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnItem());
    }

    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(3); // ���� ���� n�� �ĺ����ε� �� ������ �ȵ���
        Debug.Log("������ ���� ");
        while (true)
        {
            SpawnBread();   // ������ 1�� ��
            bread.velocity = new Vector2(-MoveSpeed, 0f);
            //yield return new WaitForSeconds(spawnInterval); // ���� ��(�극�� �����ʷ� �̵�)
        }
    }

    void SpawnBread()
    {
        Vector2 position = new Vector2(spawnPoint.position.x,
                                            Random.Range(-2f, 3.3f)); // ��������Ʈ�κ��� ���̸� ����
        GameObject Bread = Instantiate(ItemPrefab, position, Quaternion.identity);
        Destroy(Bread, ItemLifeTime);
        Debug.Log("�����ۻ��� ");
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
