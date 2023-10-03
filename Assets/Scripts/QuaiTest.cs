using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaiTest : MonoBehaviour
{
    // Start is called before the first frame update
    public  int hp;
    public HeathBar heathBar;
    private void Awake()
    {
        
    }
    void Start()
    {
        heathBar = GetComponentInChildren<HeathBar>();
        hp = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kiem"))
        {
            hp -= 25;
            heathBar.UpdateHealthBar(hp, 50);
            Debug.Log("trừ: " + 25);
        }
    }
}
