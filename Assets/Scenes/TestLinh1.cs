using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLinh1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Linh1()
    {
        TestLinh.linh1 = true;
        SceneManager.LoadScene(6);

    }

    public void Linh2()
    {
        TestLinh.linh2 = true;
        SceneManager.LoadScene(6);

    }
    public void Linh3()
    {
        TestLinh.linh3 = true;
        SceneManager.LoadScene(6);

    }
}
