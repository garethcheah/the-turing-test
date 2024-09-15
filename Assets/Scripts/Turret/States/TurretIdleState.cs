using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdleState : TurretState
{
    private Transform _target;
    private TurretMovement _turretMovement;
    private TurretLaser _laser;

    public TurretIdleState(TurretController turretController, Transform target, TurretMovement turretMovement, TurretLaser laser) : base(turretController)
    {
        _target = target;
        _turretMovement = turretMovement;
        _laser = laser;
    }

    public override void OnStateEnter()
    {
        _laser.DeactivateLaser();
    }

    public override void OnStateExit()
    {
    }

    public override void OnStateUpdate()
    {
        if (_turretController.TargetIsInRange())
        {
            _turretController.ChangeState(new TurretAttackState(_turretController, _target, _turretMovement, _laser));
        }
    }
}
