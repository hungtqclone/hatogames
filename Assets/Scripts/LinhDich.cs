using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhDich : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Transform playerTransform;
    private Transform playerTransformN_Lu;
    private float stoppingDistance = 1f;
    public LayerMask obstacleLayer ; // Layer của vật thể chướng ngại vật
    private float obstacleDetectionDistance ; // Khoảng cách kiểm tra chướng ngại vật

    private void Start()
    {
        
        obstacleLayer = LayerMask.GetMask("enemy");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerTransformN_Lu = GameObject.FindGameObjectWithTag("De1").transform;
        obstacleDetectionDistance = 1f;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            float distanceToDe1 = Vector3.Distance(transform.position, playerTransformN_Lu.position);

            // Tạo một raycast để kiểm tra vật thể ở phía bên trái
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, obstacleDetectionDistance, obstacleLayer);

            if (distanceToDe1 <= stoppingDistance || distanceToPlayer <= stoppingDistance || (hit.collider != null && hit.collider.gameObject != gameObject))
            {
                // Dừng di chuyển khi cách player đủ gần hoặc có vật thể ở phía bên trái
                moveSpeed = 0f;
            }
            else
            {
                // Tiếp tục di chuyển khi cách player đủ xa và không có vật thể ở phía bên trái
                moveSpeed = 2f;
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
    }
}
