using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : ObjectHealth
{
    [SerializeField]
    private UnityEvent<int> _onHealthCnange;

    protected override void Start()
    {
        base.Start();
        _onHealthCnange.Invoke(GetCurrenHealth());
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Debug.Log(_currentHealth);
    }
}
