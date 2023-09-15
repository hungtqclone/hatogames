using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ChuyenScreen : MonoBehaviour
{
    public GameObject panel;
    public GameObject pausePanel;
    public void StartNe()
    {
        SceneManager.LoadScene(1);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
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
        SceneManager.LoadScene(6);
    }
    public void QuaMan2()
    {
        SceneManager.LoadScene(7);
    }
    public void QuaMan3()
    {
        SceneManager.LoadScene(5);
    }
    public void QuaMan4()
    {
        SceneManager.LoadScene(5);
    }

    public void OpenPausePanel()
    {
        panel.SetActive(true);
    }

    public void PauseGame()
    {
       
        Time.timeScale = 0; // Tạm dừng thời gian trong màn chơi
        pausePanel.SetActive(true); // Mở panel
    }

    public void ResumeGame()
    {

        Time.timeScale = 1; // Tiếp tục thời gian trong màn chơi
        pausePanel.SetActive(false); // Đóng panel
    }
}