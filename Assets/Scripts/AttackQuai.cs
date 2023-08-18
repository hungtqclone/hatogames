using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackQuai : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của enemy
    public float moveSpeed = 5f;
    public float stoppingDistance = 1f;
    public float spawnInterval = 5f; // Thời gian giữa việc sinh ra các enemy

    private float spawnTimer = 0f;
    private Transform closestEnemy;

    // Vị trí cố định để sinh ra enemy
    public Vector2 fixedSpawnPosition;

    private void Update()
    {
        // Tính toán hướng di chuyển đến enemy gần nhất
        if (closestEnemy != null)
        {
            Vector3 direction = closestEnemy.position - transform.position;
            float distanceToEnemy = direction.magnitude;

            if (distanceToEnemy > stoppingDistance)
            {
                direction.Normalize();
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }

        // Kiểm tra nếu đến thời điểm sinh enemy mới
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        // Sinh ra một enemy mới tại vị trí cố định
        GameObject newEnemy = Instantiate(enemyPrefab, fixedSpawnPosition, Quaternion.identity);
        closestEnemy = newEnemy.transform; // Cập nhật enemy gần nhất
    }
}
