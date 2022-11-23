using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBehavioure : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab;
    protected float _timeToNextShoot = 0;
    [SerializeField] protected float _startTimeToShoot;
    public int _summaryAmmo;
    [SerializeField] protected int _clipAmmo;
    [SerializeField] protected int _currentAmmo;
    [SerializeField] protected float _reloadTime;
    [SerializeField] protected Transform _bulletStartPoint;
    [SerializeField] protected bool _onReload;
    [SerializeField] protected List<PoolInitiializer> _poolInitializer;
    [SerializeField] protected Transform _parentForPool;
    [SerializeField] protected AudioClip _shootSound;
    [SerializeField] protected AudioClip _ammoSound;
    [SerializeField] protected AudioClip _reloadSound;
    [SerializeField] protected AudioSource _playSound;
    [SerializeField] protected ParticleSystem _shootParticle;
    [SerializeField] protected Transform _muzzleStartPoint;
    // Start is called before the first frame update

    public abstract void Shoot();


    public abstract void Reload();

    public void AddAmmos()
    {
        
        
            _summaryAmmo +=_clipAmmo;
        
    }
    protected int GetSummaryAmmo()
    {
        return _summaryAmmo;
    }
}
