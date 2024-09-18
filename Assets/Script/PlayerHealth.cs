using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;


    [SerializeField] private Player player;
    [SerializeField] private Image healthBar;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealth();
    }

    public void heal(float amount)
    {
        health += amount;
        health = math.clamp(health, 0, maxHealth);
        updateHealth();
    }
    
    private void updateHealth()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
}
