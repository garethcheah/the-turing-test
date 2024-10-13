using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDisabledState : TurretState
{
    private TurretLaser _laser;

    public TurretDisabledState(TurretController turretController, TurretLaser laser) : base(turretController)
    {
        _laser = laser;
    }

    public override void OnStateEnter()
    {
        _laser.DeactivateLaser();
        _laser.DisplayDisabledColor();
    }

    public override void OnStateExit()
    {
    }

    public override void OnStateUpdate()
    {
    }
}
