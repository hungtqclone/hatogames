using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TrieuHoi : MonoBehaviour
{
    public static GameObject characterPrefab; // Prefab của nhân vật phụ
    private GameObject spawnedCharacter; // Nhân vật phụ được tạo
    private float timeDelay;
    public TextMeshProUGUI time;
    public EnemySpawner enemySpawner;
    // Update is called once per frame
    private void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        timeDelay = 2f;
        time.text = "" + timeDelay;
    }
    void Update()
    {
        
        if (timeDelay >= 0)
        {
            time.text = "" + Mathf.FloorToInt(timeDelay);
        }
        else
        {
            time.text = "";
        }
        if (timeDelay >=-0.5)
        {
            timeDelay -= Time.deltaTime;
        }
        
        // Kiểm tra nút "C" đã được nhấn chưa
        if (TienGoiLinh.coins>=25 && timeDelay<=0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                enemySpawner.SpawnerLinhDM();
                TienGoiLinh.coins -= 25;
                timeDelay = 2f;
            }
            
        }
       
    }

    // Tạo nhân vật phụ từ bên phải của nhân vật chính
    void SpawnCharacter()
    {
        //Vector3 spawnPosition = transform.position + Vector3.right * 2f; // Điểm bên phải của nhân vật chính
        spawnedCharacter = Instantiate(characterPrefab, new Vector3(characterPrefab.transform.position.x, characterPrefab.transform.position.y + Random.Range(-0.2f, 0.2f), 0), Quaternion.Euler(0, 0, 0));
        spawnedCharacter.gameObject.SetActive(true);
    }
}
