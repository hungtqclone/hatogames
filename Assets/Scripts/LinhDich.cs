using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhDich : MonoBehaviour
{
    public float moveSpeed;
    private Transform playerTransform;
    private Transform playerTransformN_Lu;
    private Transform playerTransformN_Nhac;
    public float stoppingDistance ;
    public LayerMask obstacleLayer ; // Layer của vật thể chướng ngại vật
    public float obstacleDetectionDistance ; // Khoảng cách kiểm tra chướng ngại vật

    private void Start()
    {
        
        obstacleLayer = LayerMask.GetMask("enemy");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerTransformN_Lu = GameObject.FindGameObjectWithTag("De1").transform;
        playerTransformN_Nhac = GameObject.FindGameObjectWithTag("NguyenNhac").transform;
        

    }

    private void Update()
    {
        if (playerTransform != null)
        {
            float distanceToDe1 = 5;
            float distanceToDe2 = 5;
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if(playerTransformN_Lu != null)
            {
                distanceToDe1 = Vector3.Distance(transform.position, playerTransformN_Lu.position);
            }
            if (playerTransformN_Nhac != null)
            {
                distanceToDe2 = Vector3.Distance(transform.position, playerTransformN_Nhac.position);
            }
            

            // Tạo một raycast để kiểm tra vật thể ở phía bên trái
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, obstacleDetectionDistance, obstacleLayer);

            if (distanceToPlayer <= stoppingDistance || (hit.collider != null && hit.collider.gameObject != gameObject))
            {
                // Dừng di chuyển khi cách player đủ gần hoặc có vật thể ở phía bên trái
                moveSpeed = 0f;
            }
            else if (distanceToDe1 <= stoppingDistance)
            {
                moveSpeed = 0f;
            }
            else if (distanceToDe2 <= stoppingDistance)
            {
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
