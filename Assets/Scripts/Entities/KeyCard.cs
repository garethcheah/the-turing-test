using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyCard : MonoBehaviour
{
    public UnityEvent OnKeyCardAcquired;

    [SerializeField] private AudioClip _clipKeyCardAcquired;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnKeyCardAcquired?.Invoke();
            SoundFXManager.instance.PlaySoundFXClip(_clipKeyCardAcquired, transform, 1.0f);
            Destroy(gameObject);
        }
    }
}
