using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimEnemyGan : MonoBehaviour
{
    //public Transform playerTransform;  // Transform của nhân vật
    public LayerMask enemyLayer;      // Layer chứa các GameObject có tag "enemy"
    public float interactionDistance = 3.5f;  // Khoảng cách tương tác
    public Animator animator;
    private NguyenLuControler nguyenLu;
    private void Start()
    {
        nguyenLu = new NguyenLuControler();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // Kiểm tra nếu có enemy nằm trong khoảng cách tương tác
        Collider2D nearestEnemyCollider = GetNearestEnemyCollider();
        if (nearestEnemyCollider != null)
        {
            // Thực hiện sự kiện khi gặp enemy gần nhất
            //Debug.Log("Nhân vật gặp enemy gần nhất!");
            animator.SetBool("CheckQuai", true);
            
            // Ở đây, bạn có thể thực hiện animation hoặc hành động khác tùy theo yêu cầu của trò chơi
        }
        else
        {
            animator.SetBool("CheckQuai", false);

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
