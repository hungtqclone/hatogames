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

    private void Update()
    {
        // Kiểm tra nếu đến thời điểm sinh enemy mới
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemyAtPosition(new Vector3(8f, -3f, 0f)); // Thay đổi tọa độ x, y, z tại đây
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemyAtPosition(Vector3 position)
    {
        // Sinh ra một enemy mới từ Prefab và đặt vị trí theo tọa độ truyền vào
        GameObject newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
