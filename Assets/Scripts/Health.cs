using UnityEngine;


public abstract class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;

    protected int GetHealth()
    {
        return currentHealth;
    }

    protected void SetHealth(int value)
    {
        currentHealth = value;
    }
    
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
            Die();
    }

    protected virtual void Die()
    {
        
    }

}