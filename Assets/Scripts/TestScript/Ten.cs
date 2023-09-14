using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ten : MonoBehaviour
{
    public float initialSpeed ; // Tốc độ ban đầu của viên đạn
    public float angle ; // Góc ném parabol
    private Rigidbody2D rb;
    protected float maxY;
    private float temp;
   

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        // Chuyển đổi góc ném từ độ sang radian
        float radians = angle * Mathf.Deg2Rad;
        // Tính toán vận tốc theo trục x và y
        float initialVelocityX = initialSpeed * Mathf.Cos(radians);
        float initialVelocityY = initialSpeed * Mathf.Sin(radians);

        // Áp dụng vận tốc ban đầu
        Vector2 initialVelocity = new Vector2(initialVelocityX, initialVelocityY);
        rb.velocity = initialVelocity;
    }

    private void Update()
    {
        Vector2 velocity = rb.velocity;
        float speed = velocity.magnitude;
        if (speed==0)
        {
            Debug.Log("Vận tốc: " + speed);
        }
       
        
        
    }
    private void FixedUpdate()
    {
        CheckY();
    }

    protected void XoayMuiTen()
    {

        

            Quaternion rotation = transform.rotation;
            rotation.z -= 0.01f;
            transform.rotation = rotation;

        
    }
    void CheckY()
    {
        temp = transform.position.y;
        maxY = temp;
        if(maxY < temp)
        {
            maxY = temp;
        }
        else 
        {
            XoayMuiTen();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("gach"))
        {
            Destroy(gameObject);
        }
    }
    
}
