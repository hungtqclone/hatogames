using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveX;
    Rigidbody2D rb;
    public float speed;
    Animator anim;
    bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        isRight = true;
        speed = 5f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
        Animation();
        Flip();
    }
    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

    }

    void Animation()
    {
        anim.SetFloat("Speed",Mathf.Abs(moveX));
    }

    void Flip()
    {

        if (moveX > 0) isRight = true;
        else if (moveX < 0) isRight = false;
        Vector2 theScale = transform.localScale;
        if (isRight) theScale.x = 1;
        else theScale.x = -1;
        transform.localScale = theScale;
    }
}
