using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _impactPrefab;
    [SerializeField] private int _damage;

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.TryGetComponent(out IDamageble damageble))
        {
            damageble.TakeDamage(_damage);
        }
        foreach(ContactPoint contactPoint in collision.contacts)
        {
           var impact = Instantiate(_impactPrefab, transform.position, Quaternion.identity);
            Destroy(impact, 0.2f);
        }
        PoolManager.AddObject(gameObject);
        
        
    }
}
