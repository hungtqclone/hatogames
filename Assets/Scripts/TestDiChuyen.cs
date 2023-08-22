using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDiChuyen : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Horizontal Movement
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Flipping the character's sprite based on movement direction
        if (horizontalInput > 0)
        {
           RightNe(); // Facing right
        }
        else if (horizontalInput < 0)
        {
           LeftNe(); // Facing left
        }

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("gach"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("gach"))
        {
            isGrounded = false;
        }
    }

    public void LeftNe()
    {
        Debug.Log("Left button pressed!");
        rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void RightNe()
    {
        Debug.Log("right button pressed!");
        rb.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
        //transform.localScale = new Vector3(1, 1, 1); // Flip sprite to face right
    }
    public void Upne()
    {
        Debug.Log("up button pressed!");
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
