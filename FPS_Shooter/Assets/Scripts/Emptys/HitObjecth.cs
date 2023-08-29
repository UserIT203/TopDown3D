using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitObjecth : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] protected float Health;

    protected float _currentHealth;

    [SerializeField] private UnityEvent _die;

    private void Die()
    {
        _die.Invoke();
        Destroy(gameObject);
    }

    protected void SetCurrentHealth() => _currentHealth = Health;

    public virtual void ApplyDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }
}
