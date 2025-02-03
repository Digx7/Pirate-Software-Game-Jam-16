using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float CurrentHealth {get; private set;}
    public float MaxHealth = 3f;

    public FloatEvent OnDamage;
    public FloatEvent OnHeal;
    public UnityEvent OnDeath;
    public UnityEvent OnRevivify;
    private bool isDead = false;

    private void Awake()
    {
        Reset();
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        OnDamage.Invoke(damageAmount);
        Debug.Log("Health: Took " + damageAmount + " damage");

        IsDead();
    }

    public void Heal(float healAmount)
    {
        CurrentHealth += healAmount;
        OnHeal.Invoke(healAmount);
    }

    public void Revivify()
    {
        if(!isDead) return;

        Reset();
    }

    public void Reset()
    {
        CurrentHealth = MaxHealth;
    }

    private void IsDead()
    {
        if(isDead) return;
        
        if(CurrentHealth <= 0)
        {
            isDead = true;
            OnDeath.Invoke();
        }
    }
}
