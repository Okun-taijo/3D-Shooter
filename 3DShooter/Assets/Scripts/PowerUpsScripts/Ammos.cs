using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammos : PowerUp
{
    [SerializeField] private int _ammos;


  
    protected override void Activate(GameObject player)
    {
        var gun=player.GetComponentInChildren<Shooting>();
        if (gun.TryGetComponent(out Shooting shooting))
        {
            shooting.AddAmmos();
        }
        else
            Debug.Log("Error");
    }
}
