using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : GunBehavioure
{
    [SerializeField] private Camera _aimCamera;
    [SerializeField] private GameObject _weaponPrefab;
    private Vector3 _directionWithSpread;
    private Ray _findCenter;
    [SerializeField] private float _spread;


    private void Start()
    {
        
        PoolManager.SetPoolParent(_parentForPool);
        PreparePool();
        _currentAmmo = _clipAmmo;
        _onReload = false;
        _playSound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
    }
    public void RaycastToCrosshair()
    {
        _findCenter = _aimCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit _hit;
        Vector3 targetPoint;

        if (Physics.Raycast(_findCenter, out _hit))
        {
            targetPoint = _hit.point;

        }
        else
        {
            targetPoint = _findCenter.GetPoint(75);
        }

        float x = Random.Range(-_spread, _spread);
        float y = Random.Range(-_spread, _spread);

        _directionWithSpread = targetPoint - _bulletStartPoint.position + new Vector3(x, y, 0);

        //_bulletPrefab.GetComponent<BulletBehavior>().TakeDirectional(directionWithSpread);
    }

    public override void Shoot()
    {
        if(_onReload==false)
            {
             if (_currentAmmo > 0)
             {
                if (_timeToNextShoot < Time.time)
                {
                    RaycastToCrosshair();
                    Instantiate(_shootParticle.gameObject, _muzzleStartPoint.position, _muzzleStartPoint.rotation);
                    var bullet = PoolManager.GetObject(_bulletPrefab.gameObject);
                     var bulletBehaviour = bullet.GetComponent<BulletBehavior>();
                      bulletBehaviour.SetStartData(_bulletStartPoint.position, _bulletStartPoint.rotation, _directionWithSpread.normalized);
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

    public void OnShoot()
    {
        if (_weaponPrefab.activeInHierarchy)
        {

            PoolManager.SetPoolParent(_parentForPool);
            PreparePool();
            Shoot();
        }
    }
}

