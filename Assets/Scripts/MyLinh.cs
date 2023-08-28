using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLinh : MonoBehaviour
{
    //public float moveSpeed;
    //private Animator animator;
    //private void Start()
    //{
    //    animator = GetComponent<Animator>();
    //}

    //private void Update()
    //{
    //    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    //    // Kiểm tra xem có ít nhất một enemy trong bán kính hay không
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("enemy"))
    //    {
    //        animator.SetBool("CheckEnemy", true);
    //        moveSpeed = 0;
    //        Debug.Log("Da gap quai 27");
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("enemy"))
    //    {
    //        animator.SetBool("CheckEnemy", false);
    //        moveSpeed = 2;
    //        Debug.Log("chua gap quai 35");
    //    }
    //}
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
        // Kiểm tra xem có va chạm với ít nhất một enemy hay không
        KtQuai();
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

    // kiểm tra gặp quái
    private void KtQuai()
    {
        if (enemyCollisionCount > 0)
        {
            Debug.Log("số quái đã gặp" + enemyCollisionCount);
            animator.SetBool("CheckEnemy", true);
            moveSpeed = 0;
        }
        else
        {
            animator.SetBool("CheckEnemy", false);
            moveSpeed = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemyCollisionCount++;
            Debug.Log("Đã gặp quái");
        }else if (collision.gameObject.CompareTag("kiemDich"))
        {
            hp -= hpKiemDichBiTru;
            heathBar.UpdateHealthBar(hp, hpGoc);
            Debug.Log("trừ: " + hpKiemDichBiTru);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemyCollisionCount--;
            Debug.Log("Chưa gặp quái");
        }
    }
}
