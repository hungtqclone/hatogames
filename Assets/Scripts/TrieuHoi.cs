using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TrieuHoi : MonoBehaviour
{
    public static GameObject characterPrefab; // Prefab của nhân vật phụ
    private GameObject spawnedCharacter; // Nhân vật phụ được tạo
    private float timeDelay1;
    private float timeDelay2;
    private float timeDelay3;
    public TextMeshProUGUI time;
    public EnemySpawner enemySpawner;
    // Update is called once per frame
    private void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        timeDelay1 = 0;
        timeDelay2 = 0;
        timeDelay3 = 0;
        //time.text = "" + timeDelay1;
    }
    void Update()
    {
        
        if (timeDelay1 >= 0)
        {
            //time.text = "" + Mathf.FloorToInt(timeDelay1);
        }
        if (timeDelay2 >= 0)
        {
            //time.text = "" + Mathf.FloorToInt(timeDelay1);
        }
        if (timeDelay3 >= 0)
        {
            //time.text = "" + Mathf.FloorToInt(timeDelay1);
        }
        else
        {
            //time.text = "";
        }
        if (timeDelay1 >=-0.5)
        {
            timeDelay1 -= Time.deltaTime;
        }
        if (timeDelay2 >= -0.5)
        {
            timeDelay2 -= Time.deltaTime;
        }
        if (timeDelay3 >= -0.5)
        {
            timeDelay3 -= Time.deltaTime;
        }


        // Kiểm tra nút "C" đã được nhấn chưa
        if (TienGoiLinh.coins>=25 && timeDelay1<=0)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                enemySpawner.SpawnerLinhDM1();
                TienGoiLinh.coins -= 25;
                timeDelay1 = 2f;
            }

        }
        if (TienGoiLinh.coins >= 25 && timeDelay2 <= 0)
        {


            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                enemySpawner.SpawnerLinhDM2();
                TienGoiLinh.coins -= 25;
                timeDelay2 = 2f;
            }

        }
        if (TienGoiLinh.coins >= 25 && timeDelay3 <= 0)
        {

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                enemySpawner.SpawnerLinhDM3();
                TienGoiLinh.coins -= 25;
                timeDelay3 = 2f;
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
