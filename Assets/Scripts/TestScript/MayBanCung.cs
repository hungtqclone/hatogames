using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayBanCung : MonoBehaviour
{
    public float moveSpeed;
    private float speed_;
    private Animator animator;
    private int enemyCollisionCount ;
    // Start is called before the first frame update
    void Start()
    {
        speed_ = moveSpeed;
        enemyCollisionCount = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        KtQuai();
    }
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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            enemyCollisionCount--;
        }
    }
}
