using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation instance;

    [SerializeField] protected Animator anim;
    [SerializeField] public static bool isShooting;
    

    // Start is called before the first frame update
    void Start()
    {
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
}
