using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject enemyPrefab; // Prefab của enemy
    private float spawnInterval = 1f; // Thời gian giữa việc sinh ra các enemy
    private float spawnTimer = 0f;
    private int enemyCount = 0; // Số lượng enemyPrefab đã tạo
    private void Update()
    {
        // Kiểm tra nếu đến thời điểm sinh enemy mới và số lượng enemy chưa đạt giới hạn
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && enemyCount < 10)
        {
            
            SpawnEnemyAtPosition(new Vector3(8f, -3f, 0f)); // Thay đổi tọa độ x, y, z tại đây
            enemyCount++; // Tăng số lượng enemy đã tạo
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemyAtPosition(Vector3 position)
    {
        // Sinh ra một enemy mới từ Prefab và đặt vị trí theo tọa độ truyền vào
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = position;
        //GameObject newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
