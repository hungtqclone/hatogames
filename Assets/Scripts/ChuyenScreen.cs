using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ChuyenScreen : MonoBehaviour
{
    public GameObject panel;
    public void StartNe()
    {
        SceneManager.LoadScene(1);
    }
    public void QuaCanh3()
    {
        SceneManager.LoadScene(2);
    }


    public void OpenPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
    public void QuaMan1()
    {
        SceneManager.LoadScene(3);
    }
    public void QuaMan2()
    {
        SceneManager.LoadScene(4);
    }
    public void QuaMan3()
    {
        SceneManager.LoadScene(5);
    }
    public void QuaMan4()
    {
        SceneManager.LoadScene(5);
    }
}