using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScripts : MonoBehaviour
{

    public static bool map1 = false,map2 = false,map3 = false,map4 =  false;
    public GameObject manhMap1;
    public GameObject manhMap2;
    public GameObject manhMap3;
    public GameObject manhMap4;
    public GameObject moRuong;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        manhMap1.SetActive(map1);
        manhMap2.SetActive(map2);
        manhMap3.SetActive(map3);
        manhMap4.SetActive(map4);

        if(map1 && map2 && map3 && map4) moRuong.SetActive(true);

    }
}
