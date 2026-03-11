using UnityEngine;

/// <summary>
/// Universal Health Script
/// </summary>
public class HealthScript : MonoBehaviour
{
    //Properties
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }

    //Constructor
    public HealthScript(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    //Methods

    public void TakeDamage(int amount)
    {
        if(amount <= 0)
        {
            Debug.Log("Cannot Take that amount of damage");
        }
        else
        {
            CurrentHealth = CurrentHealth - amount;
        }
    }

    public void Heal(int amount)
    {
        if (amount <= 0)
        {
            Debug.Log("Cannot heal for that amont");
        }
        else
        {
            CurrentHealth = CurrentHealth + amount;
            if(CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }
    }

    public void RestoreHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public void IncreaseMaxHealth(int amount)
    {
        if (amount <= 0)
        {
            Debug.Log("Cannot increase by that amont");
        }
        else
        {
            MaxHealth = MaxHealth + amount;
            RestoreHealth();
        }
    }
}
