using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : MonoBehaviour
{
    [SerializeField] private Animator _doubleDoorAnimator;
    [SerializeField] private bool _isLocked = true;
    [SerializeField] private bool _keepOpen = false;
    [SerializeField] private AudioClip _clipDoorOpening;

    public void LockDoor()
    {
        _isLocked = true;
    }

    public void UnlockDoor()
    {
        _isLocked = false;
    }

    public void OpenDoor(bool state)
    {
        if (!_isLocked)
        {
            _doubleDoorAnimator.SetBool("IsDoorOpening", state);
            SoundFXManager.instance.PlaySoundFXClip(_clipDoorOpening, transform, 1.0f);
        }
    }

    private void Start()
    {
        if (_keepOpen)
        {
            OpenDoor(true);
        }
    }
}
