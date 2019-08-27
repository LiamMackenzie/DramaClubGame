using System;
public class HealthSystem
{
    public event EventHandler OnHealthChanged;
    private int Health;
    private int MaxHealth;
    public HealthSystem(int MaxHealth)
    {
        this.MaxHealth = MaxHealth;
        Health = MaxHealth;
    }

    public int GetHealth()
    {
        return Health;
    } 

    public float GetHealthPecentage()
    {
        return (float)Health / MaxHealth;
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
        if(Health < 0 )
        {
            Health = 0;
        }
        if(OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }

    public void Heal(int healAmount)
    {
        Health += healAmount;
        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        if(OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }

}
