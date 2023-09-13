using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TestListLinh : MonoBehaviour
{
    [SerializeField] protected List<Transform> listChonLinh1;
    [SerializeField] protected List<Transform> listOtuong;
    [SerializeField] protected List<Transform> listOtuong1;
    [SerializeField] protected List<Transform> listOtuong2;
    [SerializeField] protected List<Transform> listOtuong3;
    [SerializeField] protected Transform listLinh1;
    [SerializeField] protected Transform listOtuong11;
    [SerializeField] protected Transform listOtuong22;
    [SerializeField] protected Transform listOtuong33;
    [SerializeField] protected Transform Otuong1;
    [SerializeField] protected Transform holder;
    [SerializeField] protected SavingFile savingFile;
    protected int solider1;
    protected int solider2; 
    protected int solider3;
    protected string nameSolider1, nameSolider2,nameSolider3;

  
    
    // Start is called before the first frame update
    void Start()
    {
        savingFile = GameObject.Find("SaveData").GetComponent<SavingFile>();

        listChonLinh1 = new List<Transform>();
        solider1 = SavingFile.solider1;
        solider2 = SavingFile.solider2;
        solider3 = SavingFile.solider3;
        //listOtuong = new List<Transform>();
        nameSolider1 = "GameObject (" + SavingFile.solider1 + ")";
        nameSolider2 = "GameObject (" + SavingFile.solider2 + ")";
        nameSolider3 = "GameObject (" + SavingFile.solider3 + ")";
        ListLinh();
    }



    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        
        if(solider1 != SavingFile.solider1 || solider2 != SavingFile.solider2 || solider3 != SavingFile.solider3)
        {
            listOtuong1[SavingFile.solider1 - 1].gameObject.SetActive(true);
            listOtuong2[SavingFile.solider2 - 1].gameObject.SetActive(true);
            listOtuong3[SavingFile.solider3 - 1].gameObject.SetActive(true);
            //ListLinh();
            Debug.Log("thay đổi tướng");
            //listOtuong11.GetComponent<SpriteRenderer>().sprite = listChonLinh1[SavingFile.solider1 - 1].GetComponent<SpriteRenderer>().sprite;
            //listOtuong22.GetComponent<SpriteRenderer>().sprite = listChonLinh1[SavingFile.solider2 - 1].GetComponent<SpriteRenderer>().sprite;
            //listOtuong33.GetComponent<SpriteRenderer>().sprite = listChonLinh1[SavingFile.solider3 - 1].GetComponent<SpriteRenderer>().sprite;

        }

    }

    protected virtual void ListLinh()
    {
        foreach (Transform linh in listLinh1)
        {
            this.listChonLinh1.Add(linh);
            linh.gameObject.SetActive(false);
            
            //if(linh.name == nameSolider1)
            //{
            //    Transform taolinh = Instantiate(linh,new Vector3(18,5,0),Quaternion.Euler(0,0,0));
            //    taolinh.parent = this.holder;
                
            //    taolinh.gameObject.SetActive(true) ;

            //}
            //if (linh.name == nameSolider2)
            //{
            //    Debug.Log("@@@@@@@@@@@@@@@ 57." + nameSolider2);

            //}
            //if (linh.name == nameSolider3)
            //{
            //    Debug.Log("@@@@@@@@@@@@@@@ 57." + nameSolider3);
            //}

            //if(linh == listChonLinh1[SavingFile.solider1 - 1])
            //{
            //    Transform taolinh = Instantiate(linh);
            //    taolinh.parent = this.holder;
            //    taolinh.transform.position = listOtuong[0].transform.position;
            //    taolinh.gameObject.SetActive(true);
            //}
            //if (linh == listChonLinh1[SavingFile.solider2 - 1])
            //{
            //    Transform taolinh = Instantiate(linh);
            //    taolinh.parent = this.holder;
            //    taolinh.transform.position = listOtuong[1].transform.position;
            //    taolinh.gameObject.SetActive(true);
            //}
            //if (linh == listChonLinh1[SavingFile.solider3 - 1])
            //{
            //    Transform taolinh = Instantiate(linh);
            //    taolinh.parent = this.holder;
            //    taolinh.transform.position = listOtuong[2].transform.position;
            //    taolinh.gameObject.SetActive(true);
            //}
        }
        foreach (Transform Otuong in listOtuong11)
        {
            this.listOtuong1.Add(Otuong);
            Otuong.gameObject.SetActive(false);
            if (Otuong.name == nameSolider1)
            {
                Otuong.gameObject.SetActive(true);

            }

        }
        foreach (Transform Otuong in listOtuong22)
        {
            this.listOtuong2.Add(Otuong);
            Otuong.gameObject.SetActive(false);
            if (Otuong.name == nameSolider2)
            {
                Otuong.gameObject.SetActive(true);
            }

        }
        foreach (Transform Otuong in listOtuong33)
        {
            this.listOtuong3.Add(Otuong);
            Otuong.gameObject.SetActive(false);
            if (Otuong.name == nameSolider3)
            {
                Otuong.gameObject.SetActive(true);
            }

        }
        
    }
}
