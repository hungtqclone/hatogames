using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation instance;

    [SerializeField] protected Animator anim;
    [SerializeField] public static bool isShooting;
    [SerializeField] protected GameObject vatPham;
    [SerializeField] protected PlayerMovement playerMovement;
    

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(InputManager.Instance.Horizontal));
        anim.SetBool("IsShooting", isShooting);
        anim.SetFloat("DistanceToEnemy", PlayerShooting.Instance.NearestDistance);

        
    }

    
    void Shootings()
    {

        PlayerShooting.Instance.Shooting();
        isShooting=false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            anim.SetBool("DanhGan", true);
        }
        if (collision.gameObject.CompareTag("vatPham"))
        {
            playerMovement.speed = 1;
            anim.SetBool("NhatVP", true);
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            anim.SetBool("DanhGan", false);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    
    public void DestroyVP()
    {
        // Destroy(collision.gameObject);
        Destroy(vatPham.gameObject);
        //MapScripts.map1 = true;
        //Debug.Log("Tên vật phẩm " + vatPham.name.Equals("ManhMap1"));
        if (vatPham.name.Equals("ManhMap1")) MapScripts.map1 = true;
        if (vatPham.name.Equals("ManhMap2")) MapScripts.map2 = true;
        if (vatPham.name.Equals("ManhMap3")) MapScripts.map3 = true;
        if (vatPham.name.Equals("ManhMap4")) MapScripts.map4 = true;
    }

    
}
