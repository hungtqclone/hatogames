using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NguyenNhacScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public  float speed;
    public  float speed2;
    public GameObject player;
    public float playerX;
    public Animator animator;
    public bool Attack;
    public float doiMat;
    private bool checkThu;
    public float VCong;
    public static bool checkGapQuai;
    private float randomKhoangCach;
    private void Start()
    {
        
        randomKhoangCach = 0;
        checkGapQuai = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Attack = true;
        speed2 = speed;
        speed = 0f;

        // Tìm game object có tag "Player" và gán cho player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        playerX = Vector2.Distance(transform.position, player.transform.position);

        if(Input.GetKey(KeyCode.X))
        {
            speed = speed2;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack = !Attack;
            if (Attack)
            {
                checkThu = false;
                Vector2 scale = transform.localScale;

                if (scale.x < 0)
                {
                    scale.x *= -1;
                    transform.localScale = scale;
                }
            }
            else
            {
                randomKhoangCach = Random.Range(2f, 3f);
                checkGapQuai = false;
                checkThu = true;
            }
        }

        if (!checkGapQuai)
        {
            if (Attack)
            {
                Cong();
            }
            else
            {
                Thu();
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    void Cong()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y); // Đặt vận tốc x về 0 khi dừng lại
        rb.velocity = new Vector2(speed, rb.velocity.y);
        animator.SetFloat("Speed", 1);
    }

    void Thu()
    {
        if (playerX >= randomKhoangCach)
        {
            Vector2 scale = transform.localScale;
            if (transform.position.x > player.transform.position.x && scale.x > 0
                || transform.position.x < player.transform.position.x && scale.x < 0)
            {
                Debug.Log("chay truoc");

                scale.x *= -1;
                transform.localScale = scale;
            }
            if (checkThu)
            {
                animator.SetFloat("Speed", 2);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * 2.5f * Time.deltaTime);
                Debug.Log("chay");
                
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                animator.SetFloat("Speed", 1);
            }


        }
        else
        {
            checkThu = false;
            animator.SetFloat("Speed", 0);
            Vector2 directionToPlayer = player.transform.position - transform.position;
            IEnumerator FlipScaleAfterDelay(Vector2 _scale)
            {
                yield return new WaitForSeconds(0.5f);  // Chờ 0.5 giây
                _scale.x *= -1;
                transform.localScale = _scale;
            }
            if (directionToPlayer.x > 0)
            {
                // ben trai player
                //Debug.Log("ben trai player");
            }
            else if (directionToPlayer.x < 0)
            {
                // ben phai player
                //Debug.Log("ben phai player");
                Vector2 scale = transform.localScale;
                if (scale.x < 0)
                {
                    //scale.x *= -1;
                    //transform.localScale = scale;
                    StartCoroutine(FlipScaleAfterDelay(scale));
                }
            }
        }
    }
}
