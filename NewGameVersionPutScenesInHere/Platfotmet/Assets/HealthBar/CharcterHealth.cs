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
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        
        
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            DealDamge(6);
            healthBar.value = CalculateHealth();
        }
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
        //Debug.Log("You died");
    }

    
}
