using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    [SerializeField] private AudioClip _clipPadActivated;
    [SerializeField] private int _numberOfCubesToActivate = 2;

    private int numberOfCubesOnPad;

    public bool IsActivated()
    {
        return numberOfCubesOnPad >= _numberOfCubesToActivate;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            numberOfCubesOnPad++;

            if (numberOfCubesOnPad >= _numberOfCubesToActivate)
            {
                OnActivate?.Invoke();
                SoundFXManager.instance.PlaySoundFXClip(_clipPadActivated, transform, 1.0f);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            numberOfCubesOnPad--;

            if (numberOfCubesOnPad < _numberOfCubesToActivate)
            {
                OnDeactivate?.Invoke();
            }
        }
    }
}
