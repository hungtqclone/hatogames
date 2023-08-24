using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimEnemy : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float _speed;
    public NguyenLuControler nguyenLu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            //NguyenLuControler.speed = 0;
            nguyenLu.setSpeed(0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            //NguyenLuControler.speed = 3;
            nguyenLu.setSpeed(_speed);
        }
    }
}
