using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NguyenLuControler : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public GameObject player;
    public float playerX;
    public Animator animator;
    public bool Attack;
    public float doiMat;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Attack = true;
    }

    private void Update()
    {
        playerX = Vector2.Distance(transform.position, player.transform.position);
        
        if (Input.GetKeyDown(KeyCode.D))

        {
            // Di chuyển enemy đến vị trí của nhân vật chính
            Attack = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack = true;

        }
        if (Attack)
        {
            Cong();
        }
        else
        {
            Thu();
        }


    }
    void Cong()
    {
        if (playerX <= 5)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Debug.Log(">>>>>>>>>" + rb.velocity.x);
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }
    void Thu()
    {
        
        if (playerX >= 2)
        {
            Vector2 scale = transform.localScale;
            if (transform.position.x > player.transform.position.x && scale.x > 0)
            {
                Debug.Log(">>>>>>>>>>>>>>>>>>>>");

                scale.x *= -1;
                 transform.localScale = scale;
            }
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

    }
}
