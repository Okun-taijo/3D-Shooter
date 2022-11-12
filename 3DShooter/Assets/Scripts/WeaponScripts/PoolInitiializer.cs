using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolInitiializer 
{
    [SerializeField] private GameObject _gameObjectPrefab;
    [SerializeField] private int _objectCount;

    public GameObject ObjectPrefab => _gameObjectPrefab;
    public int ObjestCount => _objectCount;
}
