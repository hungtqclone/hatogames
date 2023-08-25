using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimEnemy2 : MonoBehaviour
{
    public LayerMask enemyLayer;      // Layer chứa các GameObject có tag "enemy"
    public float interactionDistance;  // Khoảng cách tương tác
    public Animator animator;
    private bool check;
    private void Start()
    {
        check = true;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        KiemTra();
    }
    private void KiemTra()
    {
        Collider2D nearestEnemyCollider = GetNearestEnemyCollider();

        if (nearestEnemyCollider != null)
        {
            // Thực hiện sự kiện khi gặp enemy gần nhất
            //Debug.Log("Nhân vật gặp enemy gần nhất!");
            animator.SetBool("CheckQuai", true);
            animator.SetFloat("Speed", 0);
            if (check)
            {
                Debug.Log("da gap quai");
                NguyenNhacScript.checkGapQuai = true;
                check = false;
            }


            // Ở đây, bạn có thể thực hiện animation hoặc hành động khác tùy theo yêu cầu của trò chơi
        }
        else
        {
            animator.SetFloat("Speed", 1);
            animator.SetBool("CheckQuai", false);
            NguyenNhacScript.checkGapQuai = false;
            // NguyenNhacScript.checkGapQuai = false;
            check = true;

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
}
