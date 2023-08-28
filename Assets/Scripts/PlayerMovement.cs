using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float horizontal;
    [SerializeField] protected float speed = 3f;

    [SerializeField] protected Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.horizontal = InputManager.Instance.Horizontal;
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        Vector2 theScale = transform.parent.localScale;
        if(horizontal > 0 && theScale.x < 0 || horizontal < 0 && theScale.x > 0)
        {
            theScale.x *= -1;
        }
        if (PlayerAnimation.isShooting == true && theScale.x < 0)  theScale.x *= -1; 
        transform.parent.localScale = theScale;

    }
}
