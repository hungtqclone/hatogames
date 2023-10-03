using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiemTraVaCham : MonoBehaviour
{
    public Transform arow;
    public float timeDelay;
    // Start is called before the first frame update
    void Start()
    {
        //timeDelay = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //timeDelay -= Time.deltaTime;
        //if (timeDelay <= 0)
        //{
        //    Transform bulletArrow = Instantiate(arow);
        //    bulletArrow.gameObject.SetActive(true);
        //    timeDelay = 2f;
        //}
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Bắt va cham Enemy");
        }
    }
    public void GoiTen()
    {
        Transform bulletArrow = Instantiate(arow,arow.transform.position,Quaternion.Euler(0,0,0));
        bulletArrow.gameObject.SetActive(true);
    }
}
