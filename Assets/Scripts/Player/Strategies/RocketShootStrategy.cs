using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShootStrategy : IShootStrategy
{
    private ShootInteractor _shootInteractor;
    private Transform _shootPoint;
    private Transform _cameraTransform;
    private float _shootForce;

    public RocketShootStrategy(ShootInteractor shootInteractor, Transform shootPoint, float shootForce, Transform cameraTransform)
    {
        _shootInteractor = shootInteractor;
        _shootPoint = shootPoint;
        _shootForce = shootForce;
        _cameraTransform = cameraTransform;

        // Change Gun Color
        _shootInteractor.gunRenderer.material.color = _shootInteractor.rocketGunColor;
    }

    public void Shoot()
    {
        PooledObject rocketFromPool = _shootInteractor.rocketPool.GetPooledObject();

        rocketFromPool.gameObject.SetActive(true);

        Rigidbody rocket = rocketFromPool.GetComponent<Rigidbody>();

        rocket.transform.position = _shootPoint.position;
        rocket.transform.rotation = _shootPoint.rotation;
        rocket.velocity = _cameraTransform.forward * _shootForce;

        _shootInteractor.bulletPool.DestroyPooledObject(rocketFromPool, 5.0f);
    }
}
