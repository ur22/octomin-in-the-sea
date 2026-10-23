using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public static HealthBarScript instance { get; private set; } 

    public Image healthBarImage; 

    void Awake()
    {
        instance = this;
    }

    public void SetValue(float value)
    {
        
        value = Mathf.Clamp01(value);
        healthBarImage.fillAmount = value;
    }
}


