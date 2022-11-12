using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : GunBehavioure
{
    [SerializeField] private Transform _parentForPool;
    private void Start()
    {
        PoolManager.SetPoolParent(_parentForPool);
        PreparePool();
        _currentAmmo = _clipAmmo;
        _onReload = false;
    }
    
    
    public override void Shoot()
    {
        if(_onReload==false)
            {
             if (_currentAmmo > 0)
             {
                if (_timeToNextShoot < Time.time)
                {
                    // var bullet = Instantiate(_bulletPrefab, _bulletStartPoint.position, _bulletStartPoint.rotation);
                    var bullet = PoolManager.GetObject(_bulletPrefab.gameObject);
                    var bulletBehaviour = bullet.GetComponent<BulletBehavior>();
                    bulletBehaviour.SetStartData(_bulletStartPoint.position, _bulletStartPoint.rotation);
                    bulletBehaviour.Run();
                    _currentAmmo -= 1;
                    _timeToNextShoot = Time.time + _startTimeToShoot;
                }

             }
             else
             {
                Reload();
             }
        }
    }
    public override void Reload()
    {
       StartCoroutine(Reloading());
        if (_summaryAmmo >= _clipAmmo && _currentAmmo != _clipAmmo)
        {
            _currentAmmo = _clipAmmo;
            _summaryAmmo -= _clipAmmo;
        }
        if (_summaryAmmo < _clipAmmo)
        {
            _currentAmmo = _summaryAmmo;
            _summaryAmmo = 0;
        };
    }

    private IEnumerator Reloading()
    {
        _onReload = true;
        yield return new WaitForSeconds(2);
        _onReload = false;    
    }

    private void PreparePool()
    {
        foreach(var poolData in _poolInitializer)
        {
            PoolManager.Initialize(poolData.ObjectPrefab, poolData.ObjestCount);    
        }
    }
}

