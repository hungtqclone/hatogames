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
    public Animator animator;
    private Rigidbody2D rb2d;
    private bool die;
    //Start is called before the first frame update
    void Start()
    {
     
        die = true;
        checkHoiMau = false;
        heathBar = GetComponentInChildren<HeathBar>();
        hpGoc = hp;
        rb2d = GetComponent<Rigidbody2D>();
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
            if (hp< hpGoc && checkHoiMau)
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
            // NguyenNhacScript.speed = 0;
            if (rb2d != null)
            {
                rb2d.simulated = false; // Tắt tính năng mô phỏng của Rigidbody2D
            }
            else
            {
                Debug.LogWarning("Rigidbody2D không được tìm thấy trên đối tượng này.");
            }
            if(die)
            {
                animator.SetTrigger("Die");
                die = false;
            }

        }
    }
    public void Die()
    {
        Destroy(gameObject);
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
