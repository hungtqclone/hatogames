using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhanVatHealthBar : MonoBehaviour
{
    public float HpHoiTheoTime;
    public float timeHoiHp;
    public float hp;
    public float hpKiemDichBiTru;
    private bool checkHoiMau;
    private float hpGoc;
    private HeathBar heathBar;
    //Start is called before the first frame update
    void Start()
    {
        checkHoiMau = false;
        heathBar = GetComponentInChildren<HeathBar>();
        hpGoc = hp;
        StartCoroutine(HoiHP());
    }

    // Update is called once per frame
    void Update()
    {
        KtHP();
    }

   
    IEnumerator HoiHP()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeHoiHp);
            if (hp<100 && checkHoiMau)
            {
                    hp += HpHoiTheoTime;
                    heathBar.UpdateHealthBar(hp, hpGoc);
                    Debug.Log("Hồi máu" + HpHoiTheoTime);
                    if (hp > hpGoc)
                    {
                        hp = hpGoc;
                    }
            }
            
        }
    }
    private void KtHP()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kiemDich"))
        {
            hp -= hpKiemDichBiTru;
            heathBar.UpdateHealthBar(hp, hpGoc);
            Debug.Log("trừ: " + hpKiemDichBiTru);
            checkHoiMau = false;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            checkHoiMau = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            checkHoiMau = true;
        }
    }
}
