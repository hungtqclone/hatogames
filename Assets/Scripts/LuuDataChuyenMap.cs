using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuuDataChuyenMap : MonoBehaviour
{
    private static LuuDataChuyenMap instance;
    public static LuuDataChuyenMap Instance { get => instance; }
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
