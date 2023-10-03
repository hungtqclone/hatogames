using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    // Start is called before the first frame update
    void Start()
    {
        this.LoadComponents();
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void LoadComponents()
    {
        this.LoadPrefabs();
        this.HidePrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        Transform prefabsObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj)
        {
            this.prefabs.Add(prefab);
        }
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);

        }
    }
}
