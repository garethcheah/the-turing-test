using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootStrategy : IShootStrategy
{
    private ShootInteractor _shootInteractor;
    private Transform _shootPoint;
    private Transform _cameraTransform;
    private AudioClip _audioClip;
    private float _shootForce;

    public BulletShootStrategy(ShootInteractor shootInteractor, Transform shootPoint, float shootForce, Transform cameraTransform, AudioClip audioClip)
    {
        _shootInteractor = shootInteractor;
        _shootPoint = shootPoint;
        _shootForce = shootForce;
        _cameraTransform = cameraTransform;
        _audioClip = audioClip;

        // Change Gun Color
        _shootInteractor.gunRenderer.material.color = _shootInteractor.bulletGunColor;
    }

    public void Shoot()
    {
        PooledObject bulletFromPool = _shootInteractor.bulletPool.GetPooledObject();

        bulletFromPool.gameObject.SetActive(true);

        Rigidbody bullet = bulletFromPool.GetComponent<Rigidbody>();

        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.rotation;
        bullet.velocity = _cameraTransform.forward * _shootForce;

        SoundFXManager.instance.PlaySoundFXClip(_audioClip, _shootPoint, 1.0f);

        _shootInteractor.bulletPool.DestroyPooledObject(bulletFromPool, 5.0f);
    }
}
