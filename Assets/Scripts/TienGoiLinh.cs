using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TienGoiLinh : MonoBehaviour
{
    public static float coins;
    public TextMeshProUGUI txtCoin;
    // Start is called before the first frame update
    void Start()
    {
        txtCoin.text = "" + coins;
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        txtCoin.text = "" + coins;
    }
}
