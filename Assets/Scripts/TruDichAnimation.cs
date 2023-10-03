using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruDichAnimation : MonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected HealthBarThanhDM truDichHP;
    // Start is called before the first frame update
    void Start()
    {
        truDichHP = GetComponent<HealthBarThanhDM>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("HpDie", truDichHP.hp);
    }
}
