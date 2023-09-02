using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> enemyList;
    public float delayEnemy;
    public float delayCreate = 0f;
    public float dem = 0;
    public int dot1, dot2, dot3;
    [SerializeField] protected GameObject tuongDich;
    [SerializeField] protected List<Transform> listSpawner;
    public bool checkEnemy;
    // Start is called before the first frame update
    void Start()
    {
        this.listSpawner = new List<Transform>();
        delayEnemy = 0f;
        EnemyList();
        checkEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        delayEnemy -= Time.deltaTime;
        delayCreate -= Time.deltaTime;
        TaoQuaiTheoDot();
        RemoveMissingGameObjects();



    }



    protected virtual void EnemyList()
    {
        Transform prefabsEnemy = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsEnemy)
        {
            this.enemyList.Add(prefab);
        }
    }

    protected virtual void SpawnerEnemyList()
    {
        
        foreach (Transform prefab in this.enemyList)
        {
            CreateEnemy(prefab);
            

        }
    }

    

    protected virtual void CreateEnemy(Transform enemy)
    {
        Transform enemySpawner = Instantiate(enemy, enemy.transform.position, Quaternion.Euler(0, 0, 0));
        
        enemySpawner.gameObject.SetActive(true);
        listSpawner.Add(enemySpawner);
    }

    protected virtual void TaoQuaiTheoDot()
    {
        if (delayCreate <= 0f)
        {
            if (dem <= dot3 + dot2 + dot1)
            {
                if (delayEnemy <= 0f && checkEnemy)
                {
                    SpawnerEnemyList();
                    delayEnemy = 0.5f;
                    dem++;
                }

                if (dem == dot1 || dem == dot1 + dot2)
                {
                    if (listSpawner.Count == 0) {
                        checkEnemy = true;
                        Debug.Log("enemy ne");
                        delayCreate = 5f;
                        return;
                    }
                    checkEnemy = false;
                }
                if (dem == dot3 + dot2 + dot1)
                {
                    
                    tuongDich.gameObject.SetActive(true);
                    return;
                }
            }

        }
    }
    protected virtual void RemoveMissingGameObjects()
    {
        listSpawner.RemoveAll(item => item == null);
    }
}
