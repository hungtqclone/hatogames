using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListChonLinhChoi1 : MonoBehaviour
{
    [SerializeField] protected List<Transform> listOtuong1;
    [SerializeField] protected List<Transform> listOtuong2;
    [SerializeField] protected List<Transform> listOtuong3;
    [SerializeField] protected Transform listOtuong11;
    [SerializeField] protected Transform listOtuong22;
    [SerializeField] protected Transform listOtuong33;
    [SerializeField] protected Transform holder;
    [SerializeField] protected SavingFile savingFile;
    protected int solider1;
    protected int solider2;
    protected int solider3;
    protected string nameSolider1, nameSolider2, nameSolider3;


    private void Awake()
    {
        

    }
    // Start is called before the first frame update
    void Start()
    {
        savingFile = GameObject.Find("SaveData").GetComponent<SavingFile>();
        solider1 = SavingFile.solider1;
        solider2 = SavingFile.solider2;
        solider3 = SavingFile.solider3;
        //listOtuong = new List<Transform>();
        nameSolider3 = "" + SavingFile.solider3;
        nameSolider2 = "" + SavingFile.solider2;
        nameSolider1 = "" + SavingFile.solider1;
        ListLinh();
        //listOtuong1[SavingFile.solider1 - 1].gameObject.SetActive(true);
        //listOtuong2[SavingFile.solider2 - 1].gameObject.SetActive(true);
        //listOtuong3[SavingFile.solider3 - 1].gameObject.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
         listOtuong1[SavingFile.solider1 - 1].gameObject.SetActive(true);
            listOtuong2[SavingFile.solider2 - 1].gameObject.SetActive(true);
            listOtuong3[SavingFile.solider3 - 1].gameObject.SetActive(true);

      

    }

    public void ListLinh()
    {
        listOtuong1.Clear();
        listOtuong2.Clear();
        listOtuong3.Clear();

        foreach (Transform Otuong in listOtuong11)
        {
            this.listOtuong1.Add(Otuong);
            Otuong.gameObject.SetActive(false);


        }
        foreach (Transform Otuong in listOtuong22)
        {
            this.listOtuong2.Add(Otuong);
            Otuong.gameObject.SetActive(false);


        }
        foreach (Transform Otuong in listOtuong33)
        {
            this.listOtuong3.Add(Otuong);
            Otuong.gameObject.SetActive(false);


        }

    }
}
