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
    [SerializeField] protected GameObject tuongDich;
    [SerializeField] protected List<Transform> listSpawner;
    public SavingFile savingFile;
    public bool checkEnemy;
    public Transform holder;
    public List<Transform> listPositionSpawner;
    // Start is called before the first frame update
    void Start()
    {
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
        SpawnerLinhTa();


    }



    protected virtual void EnemyList()
    {
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
        Transform enemySpawner = Instantiate(enemy,new Vector3(position.transform.position.x, position.transform.position.y+ Random.Range(-0.2f, 0.2f),0) , Quaternion.Euler(0, 0, 0));
        enemySpawner.gameObject.SetActive(true);
        enemySpawner.parent = this.holder;
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
                    SpawnerEnemyList("LinhDich", listPositionSpawner[1]);
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

    public void SpawnerLinhDM()
    {
        SpawnerEnemyList("LinhDM", listPositionSpawner[0]);

    }

    public void SpawnerLinhTa()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            string linh1 = enemyList[SavingFile.solider1].name;
            SpawnerEnemyList(linh1, listPositionSpawner[0]);

        }

    }
}
