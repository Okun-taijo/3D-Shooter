using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager 
{
    private static Dictionary<string, LinkedList<GameObject>> _pooledObject = new Dictionary<string, LinkedList<GameObject>>();

    private static Transform _parentForPoolObject;

    public static void AddObject(GameObject objectToPool)
    {
        
        objectToPool.transform.SetParent(_parentForPoolObject);
        objectToPool.SetActive(false);

        if (_pooledObject.ContainsKey(objectToPool.name))
        {
            _pooledObject[objectToPool.name].AddLast(objectToPool);
        }
        else
        {
            _pooledObject[objectToPool.name] = new LinkedList<GameObject>();
            _pooledObject[objectToPool.name].AddLast(objectToPool);
        }
    }

    public static GameObject GetObject(GameObject objectFromPool)
    {
        if (_pooledObject.ContainsKey(objectFromPool.name))
        {
            if (_pooledObject[objectFromPool.name].Count > 0)
            {
                var result = _pooledObject[objectFromPool.name].Last.Value;
                _pooledObject[objectFromPool.name].RemoveLast();
                return result;
            }
            else
            {
                var result = Object.Instantiate(objectFromPool, _parentForPoolObject);
                result.name = objectFromPool.name;
                return result;
            }
        }
        else
        {
            var result = Object.Instantiate(objectFromPool, _parentForPoolObject);
            result.name = objectFromPool.name;
            return result;
        }
    }

    public static void SetPoolParent(Transform parent)
    {
        _parentForPoolObject = parent;
    }

    public static void Initialize(GameObject gameObjectToPrepare, int count)
    {
        for(int i = 0; i<count; i++)
        {
            var gameObject = Object.Instantiate(gameObjectToPrepare, _parentForPoolObject);
            gameObject.name = gameObjectToPrepare.name;
            AddObject(gameObject);
        }
    }
}
