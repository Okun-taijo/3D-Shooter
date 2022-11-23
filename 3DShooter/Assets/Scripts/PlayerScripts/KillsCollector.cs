using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillsCollector : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> ChangeKills;
 
    private static int _killCount;
   
    [SerializeField] private int _maximumKills;
    [SerializeField] private UnityEvent OnMaximumKills;

    private void Awake()
    {
        ChangeKills.Invoke(_killCount);
    }
    private void OnEnable()
    {
        KillsCounterIncreaser.OnKillsChange += KillsCount_OnKillsChange;
    }

    private void OnDisable()
    {
        KillsCounterIncreaser.OnKillsChange -= KillsCount_OnKillsChange;
    }
  

    private void KillsCount_OnKillsChange(int value)
    {
        _killCount += value;
        ChangeKills.Invoke(_killCount);

        if (_killCount >= _maximumKills)
        {
            OnMaximumKills.Invoke();
        }
    }
  
}
