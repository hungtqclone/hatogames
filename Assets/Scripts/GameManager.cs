using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected List<Transform> enemyList;
    float delayEnemy;
    // Start is called before the first frame update
    void Start()
    {
       delayEnemy = 0f;
        EnemyList();
    }

    // Update is called once per frame
    void Update()
    {
        delayEnemy -= Time.deltaTime;
        if(delayEnemy <= 0f)
        {
            SpawnerEnemyList();
            delayEnemy = 3f;
        }
    }



    protected virtual void EnemyList()
    {
        Transform prefabsEnemy = transform.Find("Prefabs");
        foreach(Transform prefab in prefabsEnemy)
        {
            this.enemyList.Add(prefab);
        }
    }

    protected virtual void SpawnerEnemyList()
    {
        foreach(Transform prefab in this.enemyList)
        {
            CreateEnemy(prefab);
            
        }
    }

    protected virtual void CreateEnemy(Transform enemy)
    {
            Transform enemySpawner = Instantiate(enemy,enemy.transform.position,Quaternion.Euler(0,0,0));
            enemySpawner.gameObject.SetActive(true);
    }

  
}
