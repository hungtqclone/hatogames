using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScripts : MonoBehaviour
{

    public static bool map1,map2,map3,map4;
    public GameObject manhMap1;
    public GameObject manhMap2;
    public GameObject manhMap3;
    public GameObject manhMap4;
    // Start is called before the first frame update
    void Start()
    {
        map1 = true;
        map2 = false;
        map3 = false;
        map4 = false;
        manhMap1 = GameObject.Find("Manh1");
        manhMap2 = GameObject.Find("Manh2");
        manhMap3 = GameObject.Find("Manh3");
        manhMap4 = GameObject.Find("Manh4");
    }

    // Update is called once per frame
    void Update()
    {
        manhMap1.SetActive(map1);
        manhMap2.SetActive(map2);
        manhMap3.SetActive(map3);
        manhMap4.SetActive(map4);
    }
}
