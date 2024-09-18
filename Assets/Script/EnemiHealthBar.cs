using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemiHealthBar : MonoBehaviour
{

    [SerializeField] private Slider Slider;
    
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        Slider.value = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
