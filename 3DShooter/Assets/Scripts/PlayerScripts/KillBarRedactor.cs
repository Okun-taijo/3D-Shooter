using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBarRedactor : MonoBehaviour
{
    public static event Action<string> KilledNameChange;
    [SerializeField] private string _name;

    public void Activate() 
    {
        KilledNameChange?.Invoke(_name);
    }
}
