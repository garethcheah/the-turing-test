using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class JumpInteractor : Interactor
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _jumpVelocity = 7.0f;

    public override void Interact()
    {
        if (PlayerInput.instance.JumpPressed && _playerMovement.IsGrounded)
        {
            _playerMovement.SetYVelocity(_jumpVelocity);
        }
    }
}
