using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnemi : MonoBehaviour
{
    [SerializeField] private float health, maxHealth = 100;
    [SerializeField] private EnemiHealthBar healthBarEnemi;

    void Start()
    {
        health = maxHealth;
        healthBarEnemi.UpdateHealthBar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()   
    {
        
    }
    public void takeDame(float damageAmount)
    {
        health -= damageAmount;
        healthBarEnemi.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
