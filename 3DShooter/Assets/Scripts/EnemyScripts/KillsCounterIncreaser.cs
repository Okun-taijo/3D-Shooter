using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillsCounterIncreaser : MonoBehaviour
{
    public static event Action<int> OnKillsChange;
    [SerializeField] private int _kill;
   
    public void Activate()
    {
        OnKillsChange?.Invoke(_kill);
    }
}
