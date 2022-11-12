using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBehavioure : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab;
    protected float _timeToNextShoot = 0;
    [SerializeField] protected float _startTimeToShoot;
    [SerializeField] protected float _summaryAmmo;
    [SerializeField] protected float _clipAmmo;
    [SerializeField] protected float _currentAmmo;
    [SerializeField] protected float _reloadTime;
    [SerializeField] protected Transform _bulletStartPoint;
    [SerializeField] protected bool _onReload;
    [SerializeField] protected List<PoolInitiializer> _poolInitializer;
    // Start is called before the first frame update

    public abstract void Shoot();


    public abstract void Reload();
   
}
