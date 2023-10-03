using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoiVPScript : MonoBehaviour
{

    [SerializeField] public Transform RoiVP;
    [SerializeField] protected HealthBarThanhDM healthBarThanhDM;
    [SerializeField] protected bool check;
    // Start is called before the first frame update
    void Start()
    {
        check = true;
        healthBarThanhDM = GetComponent<HealthBarThanhDM>();
        RoiVP.gameObject.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarThanhDM.hp <= 0 && check == true)
        {
            Vector3 thePosVP = RoiVP.transform.position;
            thePosVP.x = Random.Range(-5, 5);
            thePosVP.y = RoiVP.transform.position.y;
            RoiVP.transform.position = thePosVP;
            RoiVP.gameObject.SetActive(true);
            check = false;
        }
    }
}
