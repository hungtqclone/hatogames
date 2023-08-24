using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NguyenNhac : MonoBehaviour
{
    private Rigidbody2D rb;
    public static float speed;
    public GameObject player;
    public float playerX;
    public Animator anim;
    public static bool attack;
    public static bool checkGapQuai;
    public bool isRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        player = GameObject.FindGameObjectWithTag("Player");

        checkGapQuai = false;
        attack = true;
        isRight = true;

        speed = 1;
    }
    void Update()
    {
        Move();
        Animations();
        Flip();
    }
    void Move()
    {
        playerX = Vector2.Distance(transform.position, player.transform.position);
        rb.velocity = new Vector2(speed,rb.velocity.y);
        if(Input.GetKey(KeyCode.A) ) 
        {
            speed = 1;
            attack = true;
            isRight = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speed = 2;
            attack = false;
            isRight = false;
            checkGapQuai=false;
        }
        if(playerX >= 2 && attack == false)
        {
            rb.velocity = new Vector2(speed * -1, rb.velocity.y);
            anim.SetTrigger("Chay");
        }else if(playerX <2  && attack == false) 
        {
            speed = 0;
            isRight=true;
        }
    }
    void Animations()
    {
        if(speed == 0 && !checkGapQuai) anim.SetTrigger("DungIm");

        if (speed == 0 && checkGapQuai) anim.SetTrigger("Attack");

        if (speed == 1 ) anim.SetTrigger("DiBo");

        if(speed == 2) anim.SetTrigger("Chay");

    }
    void Flip()
    {
        Vector2 theScale = transform.localScale;
        if(isRight)
        {
            theScale.x = 0.6251f;
        }
        else if(!isRight)
        {
                theScale.x = -0.6251f;
        }
        transform.localScale = theScale;
    }  
}
