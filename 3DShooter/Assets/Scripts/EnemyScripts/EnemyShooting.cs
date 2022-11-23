using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] protected float _bulletSpeed = 20f;
    [SerializeField] protected float _lifeTime = 1f;



    // Start is called before the first frame update
    protected void Start()
    {
        if (gameObject != null)
        {
            Destroy(gameObject, _lifeTime);
        }
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        transform.position += transform.forward * _bulletSpeed * Time.fixedDeltaTime;
    }
}
