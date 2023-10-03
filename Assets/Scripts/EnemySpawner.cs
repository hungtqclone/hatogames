using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }

    [SerializeField] protected List<Transform> enemyList;
    public float delayEnemy;
    public float delayCreate = 0f;
    public float dem = 0;
    public int dot1, dot2, dot3;
    [SerializeField] protected GameObject linhDot3;
    [SerializeField] protected GameObject linhDot2;
    [SerializeField] protected List<Transform> listSpawner;
    public SavingFile savingFile;
    public bool checkEnemy;
    public Transform holder;
    public List<Transform> listPositionSpawner;

    // Start is called before the first frame update
    void Start()
    {
      if(linhDot2 != null) linhDot2.gameObject.SetActive(false);
        if (linhDot3 != null) linhDot3.gameObject.SetActive(false);
        if (checkEnemy)
        this.listSpawner = new List<Transform>();
        holder = transform.Find("Holder");
        this.listPositionSpawner = new List<Transform>();
        this.savingFile = GameObject.Find("SaveData").GetComponent<SavingFile>();
        delayEnemy = 0f;
        EnemyList();
        checkEnemy = true;
        EnemySpawner.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        delayEnemy -= Time.deltaTime;
        delayCreate -= Time.deltaTime;
        TaoQuaiTheoDot();
        RemoveMissingGameObjects();

        Debug.Log("So quai: " +listSpawner.Count);
    }



    protected virtual void EnemyList()
    {
        enemyList.Clear();
        Transform prefabsEnemy = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsEnemy)
        {
            this.enemyList.Add(prefab);
        }
        Transform prefabsEnemyPos = transform.Find("Position");
        foreach (Transform prefab in prefabsEnemyPos)
        {
            this.listPositionSpawner.Add(prefab);
        }
    }

    protected virtual void SpawnerEnemyList(string name, Transform position)
    {
        
        foreach (Transform prefab in this.enemyList)
        {
            if (prefab.name == name)
            {
                CreateEnemy(prefab,position);

            }


        }
    }

    

    protected virtual void CreateEnemy(Transform enemy,Transform position)
    {
        Transform enemySpawner = Instantiate(enemy,new Vector3(position.transform.position.x, position.transform.position.y+ Random.Range(0.1f, 0.3f),0) , Quaternion.Euler(0, 0, 0));
        enemySpawner.gameObject.SetActive(true);
        enemySpawner.parent = this.holder;
        listSpawner.Add(enemySpawner);
    }

    protected virtual void SpawnerEnemyListDM(string name, Transform position)
    {

        foreach (Transform prefab in this.enemyList)
        {
            if (prefab.name == name)
            {
                CreateEnemyDM(prefab, position);

            }


        }
    }



    protected virtual void CreateEnemyDM(Transform enemy, Transform position)
    {
        Transform enemySpawner = Instantiate(enemy, new Vector3(position.transform.position.x, position.transform.position.y + Random.Range(0.1f, 0.3f), 0), Quaternion.Euler(0, 0, 0));
        enemySpawner.gameObject.SetActive(true);
        enemySpawner.parent = this.holder;
    }
    protected virtual void TaoQuaiTheoDot()
    {
        string nameEnemySpawner = enemyList[Random.Range(0, 2)].name;
        Debug.Log(nameEnemySpawner);
        if (delayCreate <= 0f)
        {
            if (dem <= dot3 + dot2 + dot1)
            {
                if (delayEnemy <= 0f && checkEnemy)
                {
                    SpawnerEnemyList(nameEnemySpawner, listPositionSpawner[1]);
                    delayEnemy = 2f;
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
                if (dem == dot2 + dot1)
                {
                    if (linhDot2 == null)
                    {
                        return;
                    }
                    linhDot2.gameObject.SetActive(true);
                    return;
                }
                if (dem == dot3 + dot2 + dot1)
                {

                    if (linhDot3 == null)
                    {
                        return;
                    }
                    else
                    {
                        linhDot3.gameObject.SetActive(true);
                        return;
                    }
                    
                    
                }
            }

        }
    }
    protected virtual void RemoveMissingGameObjects()
    {
        listSpawner.RemoveAll(item => item == null);
    }

    public void SpawnerLinhDM1()
    {
        if (SavingFile.solider1 + 1 > enemyList.Count) return;
        string linh1 = enemyList[SavingFile.solider1 +1].name;
        SpawnerEnemyListDM(linh1, listPositionSpawner[0]);

    }
    public void SpawnerLinhDM2()
    {
        if (SavingFile.solider2 + 1 > enemyList.Count) return;

        string linh1 = enemyList[SavingFile.solider2 +1].name;
        SpawnerEnemyListDM(linh1, listPositionSpawner[0]);

    }

    public void SpawnerLinhDM3()
    {
        if (SavingFile.solider3 + 1 > enemyList.Count) return;
        string linh1 = enemyList[SavingFile.solider3 + 1].name;
        SpawnerEnemyListDM(linh1, listPositionSpawner[0]);

    }

    
}
