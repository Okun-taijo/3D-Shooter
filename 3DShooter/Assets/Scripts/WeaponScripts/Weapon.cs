using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Weapon/properties")]
public class Weapon : ScriptableObject  
{
    public Vector3 _rightHandPosition;
    public Vector3 _rightHandRotation;

    public GameObject _weaponPrefab;
}
