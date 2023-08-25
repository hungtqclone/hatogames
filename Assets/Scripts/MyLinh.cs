using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLinh : MonoBehaviour
{
    public float moveSpeed;
    private Animator animator;
    public LayerMask enemyLayer; // Layer của enemy
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        // Kiểm tra xem có ít nhất một enemy trong bán kính hay không
        if (Physics.OverlapSphere(transform.position, 10, enemyLayer).Length > 0)
        {
            // Thực hiện lệnh debug khi có ít nhất một enemy trong bán kính
            Debug.Log("Có ít nhất một enemy trong bán kính!");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            animator.SetBool("CheckEnemy", true);
            moveSpeed = 0;
            Debug.Log("Da gap quai");
        }else if (collision.gameObject.CompareTag("De1"))
        {
            Debug.Log("Da gap de1");
             animator.SetBool("CheckEnemy", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            animator.SetBool("CheckEnemy", false);
            moveSpeed = 2;
            Debug.Log("chua gap quai");
        }
    }
}
