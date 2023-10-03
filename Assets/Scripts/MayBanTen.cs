using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayBanTen : MonoBehaviour
{
    public LayerMask enemyLayer;      // Layer chứa các GameObject có tag "enemy"
    public float interactionDistance;  // Khoảng cách tương tác

    public float moveSpeed;
    private Animator animator;
    private int enemyCollisionCount = 0; // Số lượng va chạm với enemy
    //hp của linh đồng minh
    public float hp;
    public float hpKiemDichBiTru;
    public float hpGoc;
    public HeathBar heathBar;
    private Rigidbody2D rb2d;
    private void Start()
    {
        animator = GetComponent<Animator>();
        heathBar = GetComponentInChildren<HeathBar>();
        hpGoc = hp;
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        KiemTra();
        KtHP();
    }
    private void KtHP()
    {
        if (hp <= 0)
        {
            if (rb2d != null)
            {
                rb2d.simulated = false; // Tắt tính năng mô phỏng của Rigidbody2D
            }
            else
            {
                Debug.LogWarning("Rigidbody2D không được tìm thấy trên đối tượng này.");
            }
            moveSpeed = 0;
            animator.SetBool("Die", true);

        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    private void KiemTra()
    {
        Collider2D nearestEnemyCollider = GetNearestEnemyCollider();
        if (nearestEnemyCollider != null)
        {
            // Thực hiện sự kiện khi gặp enemy gần nhất
            Debug.Log("Nhân vật gặp enemy gần nhất!");
            moveSpeed = 0;
            animator.SetBool("CheckEnemy", true);

            // Ở đây, bạn có thể thực hiện animation hoặc hành động khác tùy theo yêu cầu của trò chơi
        }
        else
        {

            animator.SetBool("CheckEnemy", false);
            moveSpeed = 2;
        }
    }
    private Collider2D GetNearestEnemyCollider()
    {
        // Tìm các GameObject enemy nằm trong khoảng cách interactionDistance
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, interactionDistance, enemyLayer);

        Collider2D nearestCollider = null;
        float nearestDistance = Mathf.Infinity;

        // Duyệt qua danh sách các enemy gần nhất
        foreach (Collider2D enemyCollider in hitEnemies)
        {
            // Tính khoảng cách từ nhân vật đến enemy
            float distanceToEnemy = Vector2.Distance(transform.position, enemyCollider.transform.position);
            if (distanceToEnemy < nearestDistance)
            {
                // Cập nhật enemy gần nhất và khoảng cách tới nó
                nearestDistance = distanceToEnemy;
                nearestCollider = enemyCollider;
            }
        }

        return nearestCollider;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kiemDich"))
        {
            hp -= hpKiemDichBiTru;
            heathBar.UpdateHealthBar(hp, hpGoc);
            Debug.Log("trừ: " + hpKiemDichBiTru);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
    }
}
