using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChonLinh : MonoBehaviour
{
    public GameObject linhDM;
    public GameObject linhDich;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LinhDM()
    {
        TrieuHoi.characterPrefab = linhDM;
        SceneManager.LoadScene(4);
    }
    public void LinhDich()
    {
        TrieuHoi.characterPrefab = linhDich;
        SceneManager.LoadScene(4);
    }
}
