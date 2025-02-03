using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float CurrentHealth {get; private set;}
    public float MaxHealth = 3f;

    public FloatEvent OnDamage;
    public FloatEvent OnHeal;
    public UnityEvent OnDeath;

    private void Awake()
    {
        Reset();
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        OnDamage.Invoke(damageAmount);

        if(IsDead()) OnDeath.Invoke();
    }

    public void Heal(float healAmount)
    {
        CurrentHealth += healAmount;
        OnHeal.Invoke(healAmount);
    }

    public void Reset()
    {
        CurrentHealth = MaxHealth;
    }

    private bool IsDead()
    {
        if(CurrentHealth <= 0) return true;
        else return false;
    }
}
