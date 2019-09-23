using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    public Slider HealthBar;
    void Start()
    {
        MaxHealth = 20f;
        CurrentHealth = MaxHealth;

        HealthBar.value = CalculateHealth();
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
    void Update()
    {
        
    }
}
