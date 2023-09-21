using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine.SceneManagement;

public class WinLossScript : MonoBehaviour
{
    [SerializeField] protected GameObject panelWin;
    [SerializeField] protected GameObject panelLoss;
    [SerializeField] protected NhanVatHealthBar playerHealbar;
    [SerializeField] protected HealthBarThanhDM truDichHealbar;
    [SerializeField] protected HealthBarThanhDM truDMHealbar;
    // Start is called before the first frame update
    void Start()
    {
        if (panelWin == null || panelLoss == null || playerHealbar == null || truDichHealbar == null || truDMHealbar == null) 
        {
            Debug.LogError("Bạn chưa khởi tạo đủ");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(playerHealbar.hp <= 0 || truDMHealbar.hp <= 0)
        {
            panelLoss.SetActive(true);
            Time.timeScale = 0;
        }
        if (truDichHealbar.hp <= 0)
        {
            panelWin.SetActive(true);
            Time.timeScale = 0;

        }
        if(playerHealbar.hp > 0 && truDMHealbar.hp > 0 && truDichHealbar.hp > 0)
        {
            Time.timeScale = 1;
        }

        //else
        //{
        //    Time.timeScale = 1;
        //}
        
    }
    private void FixedUpdate()
    {
        
    }

    public virtual void ScreenHome()
    {
        SceneManager.LoadScene(0);
    }
    public virtual void ScreenMap()
    {
        
        SceneManager.LoadScene(2);
    }

}
