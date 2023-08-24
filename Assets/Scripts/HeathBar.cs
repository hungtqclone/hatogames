using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeathBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
}
