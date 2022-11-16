using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] protected float _bulletImpulse;
    [SerializeField] protected float _bulletLifeTime;
    [SerializeField] private Rigidbody _rigidBody;
    private bool _isRun = false;
    private Vector3 direct;

   


    private void Start()
    {
       
    }
    public void TakeDirectional(Vector3 directional)
    {
        direct = directional;
        transform.forward = direct.normalized;
       
    }
    protected virtual void FixedUpdate()
    {
       
        if (_isRun)
        {
            transform.position += transform.forward * _bulletImpulse * Time.fixedDeltaTime;
          
        }
    }
    public void SetStartData(Vector3 position, Quaternion quaternion)
    {
        transform.position = position;
        transform.rotation = quaternion;
        
    }

    public void Run()
    {
        gameObject.SetActive(true);
        _isRun = true;
        StartCoroutine(DelayedAction(_bulletLifeTime, OnLifeTimeEnd));
    }

    public void Stop()
    {
        _isRun = false;
    }
    public void OnLifeTimeEnd()
    {
        Stop();
        PoolManager.AddObject(gameObject);
    }

    private IEnumerator DelayedAction(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
   
}
