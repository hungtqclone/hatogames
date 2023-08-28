﻿using System.Collections;
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
    private Animator animator;
    private Rigidbody2D rb2d;
    //Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            // NguyenNhacScript.speed = 0;
            if (rb2d != null)
            {
                rb2d.simulated = false; // Tắt tính năng mô phỏng của Rigidbody2D
            }
            else
            {
                Debug.LogWarning("Rigidbody2D không được tìm thấy trên đối tượng này.");
            }
            animator.SetBool("Die", true);
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
