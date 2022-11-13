using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : GunBehavioure
{
    private void Start()
    {
        PoolManager.SetPoolParent(_parentForPool);
        PreparePool();
        _currentAmmo = _clipAmmo;
        _onReload = false;
        _playSound = GetComponent<AudioSource>();
    }
    
    
    public override void Shoot()
    {
        if(_onReload==false)
            {
             if (_currentAmmo > 0)
             {
                if (_timeToNextShoot < Time.time)
                {
                    Instantiate(_shootParticle.gameObject, _muzzleStartPoint.position, _muzzleStartPoint.rotation);
                    var bullet = PoolManager.GetObject(_bulletPrefab.gameObject);
                    var bulletBehaviour = bullet.GetComponent<BulletBehavior>();
                    bulletBehaviour.SetStartData(_bulletStartPoint.position, _bulletStartPoint.rotation);
                    bulletBehaviour.Run();
                    _currentAmmo -= 1;
                    _timeToNextShoot = Time.time + _startTimeToShoot;
                    _playSound.PlayOneShot(_shootSound);
                    _playSound.PlayOneShot(_ammoSound);

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
        _playSound.PlayOneShot(_reloadSound);
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

