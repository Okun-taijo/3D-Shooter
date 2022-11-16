using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectHealth : MonoBehaviour, IDamageble
{
    [SerializeField] private int _maxHealth;
    public int _currentHealth;
    [SerializeField] protected UnityEvent onEndedHealth;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            onEndedHealth.Invoke();
        }
    }
    
    public void AddHealth(int value)
    {
        if (value > 0)
        {
            _currentHealth += value;
        }
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    protected int GetCurrenHealth()
    {
        return _currentHealth;
    }
}