using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillBarCollector : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> ChangeBarName;

    private static string _killedName;
    void Awake()
    {
        ChangeBarName.Invoke(_killedName);
    }
    private void OnEnable()
    {
        KillBarRedactor.KilledNameChange += BarChange_OnKillChange;
    }
    private void OnDisable()
    {
        KillBarRedactor.KilledNameChange -= BarChange_OnKillChange;
    }

    private void BarChange_OnKillChange(string name)
    {
        _killedName = name;
        ChangeBarName.Invoke(_killedName);
    }
}
