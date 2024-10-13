using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Animator _liftAnimator;

    private bool _isEnabled = false;
    private bool _isLiftGrounded = true;

    public void EnableLift()
    {
        _isEnabled = true;
    }

    public void DisableLift()
    {
        _isEnabled = false;
    }

    public void ActivateLift()
    {
        if (_isEnabled)
        {
            _liftAnimator.SetBool("IsLiftGoingUp", _isLiftGrounded);
            _isLiftGrounded = !_isLiftGrounded;
        }
    }
}
