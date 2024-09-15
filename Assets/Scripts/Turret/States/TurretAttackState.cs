using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackState : TurretState
{
    private Transform _target;
    private TurretMovement _turretMovement;
    private TurretLaser _laser;

    public TurretAttackState(TurretController turretController, Transform target, TurretMovement turretMovement, TurretLaser laser) : base(turretController)
    {
        _target = target;
        _turretMovement = turretMovement;
        _laser = laser;
    }

    public override void OnStateEnter()
    {
        _laser.ActivateLaser();
    }

    public override void OnStateExit()
    {
    }

    public override void OnStateUpdate()
    {
        if (_turretController.TargetIsInRange())
        {
            _turretMovement.RotateTurretTowardsTarget(_target);
        }
        else
        {
            _turretController.ChangeState(new TurretIdleState(_turretController, _target, _turretMovement, _laser));
        }
    }
}
