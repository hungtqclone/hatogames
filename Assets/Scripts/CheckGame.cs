using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGame : MonoBehaviour
{
    public bool ChayLanDau = SavingFile.chayLanDau;
    public int solider1 = 1;
    public int solider2 = 2;
    public int solider3 = 3;
    public int level = 1;
    public int coin = 0;
    public int soSao = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(ChayLanDau)
        {
            SavingFile.level = level;
            SavingFile.coin = coin;
            SavingFile.soSao = soSao;
            SavingFile.solider1 = solider1;
            SavingFile.solider2 = solider2;
            SavingFile.solider3 = solider3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
