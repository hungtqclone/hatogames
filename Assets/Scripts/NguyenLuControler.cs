using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NguyenLuControler : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject player;
    public float playerX;
    public Animator animator;
    public bool Attack;
    public float doiMat;
    private bool checkThu;
    public float VCong;
    public static bool checkGapQuai;
    private void Start()
    {
        checkGapQuai = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Attack = true;

        // Tìm game object có tag "Player" và gán cho player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        playerX = Vector2.Distance(transform.position, player.transform.position);

        if (Input.GetKeyDown(KeyCode.D))
        {
            // Di chuyển enemy đến vị trí của nhân vật chính
            checkGapQuai = false;
            checkThu = true;
            Attack = false;
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            checkThu = false;
            Attack = true;
            Vector2 scale = transform.localScale;
          
            if (scale.x < 0)
            {
                scale.x *= -1;
                transform.localScale = scale;
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
        if (playerX >= 2)
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
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed* 2.5f * Time.deltaTime);
                animator.SetFloat("Speed", 2);
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

    public void SetCheckQuai(bool _check)
    {
        checkGapQuai = _check;
    }
}
