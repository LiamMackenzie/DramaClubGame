using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharcterHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Slider healthBar;
    
    void Start()
    {
        maxHealth = 20f;
        currentHealth = maxHealth;
        healthBar.value = CalculateHealth();
        
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            DealDamge(6);
        }
        
    }

    float CalculateHealth()
    {
        return currentHealth/maxHealth;
    }

    void DealDamge(float damageValue)
    {
        currentHealth -= damageValue;
        healthBar.value = CalculateHealth();

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        currentHealth = 0;
        Debug.Log("You died");
    }
}
