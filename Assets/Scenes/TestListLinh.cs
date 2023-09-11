using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestListLinh : MonoBehaviour
{
    [SerializeField] protected List<Transform> listChonLinh1;
    [SerializeField] protected Transform listLinh1;
    [SerializeField] protected SavingFile savingFile;
    protected int solider1;
    protected int solider2; 
    protected int solider3;
    // Start is called before the first frame update
    void Start()
    {
        savingFile = GameObject.Find("SaveData").GetComponent<SavingFile>();
        listChonLinh1 = new List<Transform>();
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
            listChonLinh1[SavingFile.solider1 - 1].gameObject.SetActive(true);
            listChonLinh1[SavingFile.solider2 - 1].gameObject.SetActive(true);
            listChonLinh1[SavingFile.solider3 - 1].gameObject.SetActive(true);
        }
        
    }

    protected virtual void ListLinh()
    {
        foreach (Transform linh in listLinh1)
        {
            this.listChonLinh1.Add(linh);
            linh.gameObject.SetActive(false);
        }
    }
}
