using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected List<Transform> enemyList;
    public float delayEnemy;
    public float delayCreate = 0f;
    public float dem = 0;
    public int dot1, dot2, dot3;
    [SerializeField] protected GameObject tuongDich;
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
        delayCreate -= Time.deltaTime;

        TaoQuaiTheoDot();
        
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

    protected virtual void TaoQuaiTheoDot()
    {
        if (dem == dot3+ dot2 + dot1) return;
        if (delayCreate <= 0f)
        {
            if (dem <= dot3+ dot2 + dot1)
            {
                if (delayEnemy <= 0f)
                {
                    SpawnerEnemyList();
                    delayEnemy = 3f;
                    dem++;
                }
                
                if (dem == dot1 || dem == dot1 + dot2)
                {
                    delayCreate = 30f;
                }
                if (dem == dot3 + dot2 + dot1)
                {
                  GameObject tuongDich1 =  Instantiate(tuongDich, tuongDich.transform.position, Quaternion.Euler(0, 0, 0));
                    tuongDich1.gameObject.SetActive(true);
                }
            }

        }
    }
}
