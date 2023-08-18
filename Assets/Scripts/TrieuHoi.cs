using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrieuHoi : MonoBehaviour
{
    public GameObject characterPrefab; // Prefab của nhân vật phụ
    private GameObject spawnedCharacter; // Nhân vật phụ được tạo
    private bool check = true;

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra nút "C" đã được nhấn chưa
        if (check)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                SpawnCharacter();
            }
        }
       
    }

    // Tạo nhân vật phụ từ bên phải của nhân vật chính
    void SpawnCharacter()
    {
        Vector3 spawnPosition = transform.position + Vector3.right * 2f; // Điểm bên phải của nhân vật chính
        spawnedCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
        check = false;
    }
}
