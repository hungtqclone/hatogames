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
    public bool checkThu;
    public float VCong;
    public static bool checkGapQuai;
    private void Start()
    {
        checkGapQuai = false;
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        Attack = true;
        speed = 1;

        // Tìm game object có tag "Player" và gán cho player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
        playerX = Vector2.Distance(transform.position, player.transform.position);

        if (Input.GetKeyDown(KeyCode.D))
        {
            speed = 2;
            // Di chuyển enemy đến vị trí của nhân vật chính
            checkGapQuai = false;
            checkThu = true;
            Attack = false;
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            checkThu = false;
            Attack = true;
            speed = 1;
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
            // Đặt vận tốc x về 0 khi dừng lại
            rb.velocity = new Vector2(speed, rb.velocity.y);
        //animator.SetTrigger("DiBo");
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
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            //animator.SetTrigger("Chay");
            

           
        }
        else
        {
            checkThu = false;
            //animator.SetTrigger("DungIm");
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

    public void setSpeed(float _speed)
    {
        speed = _speed;
    }
}
