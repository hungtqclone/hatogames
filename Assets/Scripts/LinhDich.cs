using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhDich : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float moveSpeed = 2f; // Tốc độ di chuyển của enemy
    private bool isCollidingWithPlayer = false; // Biến kiểm tra va chạm với player
    private bool isMovingLeft = false; // Biến kiểm tra việc di chuyển sang trái

    private void Update()
    {
        if (!isCollidingWithPlayer)
        {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Nếu va chạm với đối tượng có tag "Player", dừng lại và đặt biến cờ isCollidingWithPlayer thành true
            isCollidingWithPlayer = true;
            moveSpeed = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Khi không còn va chạm với player, tiếp tục di chuyển và đặt biến cờ isCollidingWithPlayer thành false
            isCollidingWithPlayer = false;
            moveSpeed = 2f; // Đặt lại tốc độ di chuyển
        }
    }

    public void StartMovingLeft()
    {
        // Kích hoạt việc di chuyển sang trái
        isMovingLeft = true;
    }
}
