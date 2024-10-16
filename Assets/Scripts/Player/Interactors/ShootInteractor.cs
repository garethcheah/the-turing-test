using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInteractor : Interactor
{
    [Header("Gun")]
    public MeshRenderer gunRenderer;
    public Color bulletGunColor;
    public Color rocketGunColor;

    [Header("Shoot")]
    public ObjectPool bulletPool;
    public ObjectPool rocketPool; 


    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _bulletShootForce = 20.0f;
    [SerializeField] private float _rocketShootForce = 40.0f;
    [SerializeField] private AudioClip _clipBulletFired;
    [SerializeField] private AudioClip _clipRocketFired;

    private float _finalShootVelocity;
    private WeaponType _weaponType;
    private IShootStrategy _currentShootStrategy;
    private bool _isWeaponsEnabled = true;

    public enum WeaponType
    {
        Primary,
        Secondary
    }

    public override void Interact()
    {

        if (_currentShootStrategy == null)
        {
            _currentShootStrategy = new BulletShootStrategy(this, _bulletSpawnPoint, _bulletShootForce, _cameraTransform, _clipBulletFired);
            _weaponType = WeaponType.Primary;
        }

        if (PlayerInput.instance.ChangeWeaponPressed)
        {
            if (_weaponType == WeaponType.Primary)
            {
                _currentShootStrategy = new RocketShootStrategy(this, _bulletSpawnPoint, _rocketShootForce, _cameraTransform, _clipRocketFired);
                _weaponType = WeaponType.Secondary;
            }
            else
            {
                _currentShootStrategy = new BulletShootStrategy(this, _bulletSpawnPoint, _bulletShootForce, _cameraTransform, _clipBulletFired);
                _weaponType = WeaponType.Primary;
            }
        }

        if (PlayerInput.instance.ShootPressed && _isWeaponsEnabled)
        {
            _currentShootStrategy.Shoot();
        }
    }

    public Transform GetShootPoint()
    {
        return _bulletSpawnPoint;
    }

    public void EnableWeapons()
    {
        _isWeaponsEnabled = true;
    }

    public void DisableWeapons()
    {
        _isWeaponsEnabled = false;
    }
}
