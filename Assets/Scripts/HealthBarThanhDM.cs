using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarThanhDM : MonoBehaviour
{
    private Animator animator;

    public float hp;
    public float hpKiemBiTru;
    private float hpGoc;
    private HeathBar heathBar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        heathBar = GetComponentInChildren<HeathBar>();
        hpGoc = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            animator.SetBool("ThanhBe", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kiemDich"))
        {
            DamgeHP(hpKiemBiTru);
            
        }else if (collision.gameObject.CompareTag("kiem"))
        {
            DamgeHP(hpKiemBiTru);

        }
        else if (collision.gameObject.CompareTag("Arrow"))
        {

            DamgeHP(20);
        }
        else if (collision.gameObject.CompareTag("CongThanh"))
        {

            DamgeHP(50);
        }
    }
    void DamgeHP(float damge)
    {
        hp -= damge;
        heathBar.UpdateHealthBar(hp, hpGoc);

    }
}
