using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDisabledState : TurretState
{
    private TurretLaser _laser;
    private AudioClip _audioClip;

    public TurretDisabledState(TurretController turretController, TurretLaser laser, AudioClip audioClip) : base(turretController)
    {
        _laser = laser;
        _audioClip = audioClip;
    }

    public override void OnStateEnter()
    {
        _laser.DeactivateLaser();
        _laser.DisplayDisabledColor();
        SoundFXManager.instance.PlaySoundFXClip(_audioClip, _laser.transform, 1.0f);
    }

    public override void OnStateExit()
    {
    }

    public override void OnStateUpdate()
    {
    }
}
