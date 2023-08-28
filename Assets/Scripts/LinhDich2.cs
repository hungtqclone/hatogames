using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhDich2 : MonoBehaviour
{
    public float moveSpeed;
    private Animator animator;
    // cac bien kiem tra khi gap quai linh, nhan vat.....
    private int enemyCollisionCount = 0; // Số lượng va chạm với enemy
    private bool gapNguyenLu;
    private bool gapNguyenNhac;
    private bool gapNguyenHue;
    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    public float hp;
    public float hpKiemBiTru;
    public float hpGoc;
    public HeathBar heathBar;
    private void Start()
    {
        animator = GetComponent<Animator>();
        gapNguyenLu = false;
        gapNguyenNhac = false;
        gapNguyenHue = false;
        heathBar = GetComponentInChildren<HeathBar>();
        hpGoc = hp;
        //hp = 50;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Kiểm tra xem có va chạm với ít nhất một enemy hay không
        KtVaCham();
        KtDich();
    }
    private void KtDich()
    {
        if (hp <= 0)
        {
            animator.SetBool("Die", true);
            moveSpeed = 0;
        }
    }
    public void GietDich()
    {
        Destroy(gameObject);
    }
    // kiểm tra gặp quái
    private void KtVaCham()
    {
        if (enemyCollisionCount > 0 || gapNguyenLu || gapNguyenNhac || gapNguyenHue)
        {
            //Debug.Log("số quái đã gặp" + enemyCollisionCount);
            animator.SetBool("CheckEnemy", true);
            moveSpeed = 0;
        }
        else
        {
            animator.SetBool("CheckEnemy", false);
            moveSpeed = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("linh"))
        {
            enemyCollisionCount++;
            //Debug.Log("Đã gặp quái");
        }else if (collision.gameObject.CompareTag("De1"))
        {
            gapNguyenLu = true;
            //Debug.Log("Đã gặp De1");
        }else if (collision.gameObject.CompareTag("NguyenNhac"))
        {
            gapNguyenLu = true;
            //Debug.Log("Đã gặp De1");
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        }else if (collision.gameObject.CompareTag("kiem"))
        {
            
            
            DamgeHP(hpKiemBiTru);
            Debug.Log("trừ: " + hpKiemBiTru);
        }else if (collision.gameObject.CompareTag("Player"))
        {

            gapNguyenHue = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("linh"))
        {
            enemyCollisionCount--;
            //Debug.Log("Chưa gặp quái");
        }
        else if (collision.gameObject.CompareTag("De1"))
        {
            gapNguyenLu = false;
            //Debug.Log("Đã gặp De1");
        }
        else if (collision.gameObject.CompareTag("NguyenNhac"))
        {
            gapNguyenLu = false;
            //Debug.Log("Đã gặp De1");
        }
        else if (collision.gameObject.CompareTag("Player"))
        {

            gapNguyenHue = false;
        }
        else if (collision.gameObject.CompareTag("Arrow"))
        {

            DamgeHP(20);
        }
    }

    void DamgeHP(float damge)
    {
        hp -= damge;
        heathBar.UpdateHealthBar(hp, hpGoc);
        
    }
}
