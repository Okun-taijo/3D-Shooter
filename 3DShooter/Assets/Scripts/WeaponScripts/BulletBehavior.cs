using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] protected float _bulletImpulse;
    [SerializeField] protected float _bulletLifeTime;
    [SerializeField] protected Rigidbody _bulletRigidbody;
    private bool _isRun = false;

  
 
    protected virtual void FixedUpdate()
    {
        if (_isRun)
        {
            _bulletRigidbody.AddForce(Vector3.forward * _bulletImpulse, ForceMode.Impulse);
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
    private void OnLifeTimeEnd()
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
