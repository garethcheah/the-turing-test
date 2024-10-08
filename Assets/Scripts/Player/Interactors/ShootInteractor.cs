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
    [SerializeField] public ObjectPool bulletPool;
    [SerializeField] public ObjectPool rocketPool;


    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private float _bulletShootForce = 20.0f;
    [SerializeField] private float _rocketShootForce = 40.0f;

    private float _finalShootVelocity;
    private WeaponType _weaponType;
    private IShootStrategy _currentShootStrategy;

    public enum WeaponType
    {
        Primary,
        Secondary
    }

    public override void Interact()
    {
        if (_currentShootStrategy == null)
        {
            _currentShootStrategy = new BulletShootStrategy(this, _bulletSpawnPoint, _bulletShootForce, _cameraTransform);
            _weaponType = WeaponType.Primary;
        }

        if (PlayerInput.instance.ChangeWeaponPressed)
        {
            if (_weaponType == WeaponType.Primary)
            {
                _currentShootStrategy = new RocketShootStrategy(this, _bulletSpawnPoint, _rocketShootForce, _cameraTransform);
                _weaponType = WeaponType.Secondary;
            }
            else
            {
                _currentShootStrategy = new BulletShootStrategy(this, _bulletSpawnPoint, _bulletShootForce, _cameraTransform);
                _weaponType = WeaponType.Primary;
            }
        }

        if (PlayerInput.instance.ShootPressed)
        {
            _currentShootStrategy.Shoot();
        }
    }

    public Transform GetShootPoint()
    {
        return _bulletSpawnPoint;
    }
}
