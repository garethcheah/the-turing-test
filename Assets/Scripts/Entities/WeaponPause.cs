using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponPause : MonoBehaviour
{
    public UnityEvent OnWeaponsDisabled;
    public UnityEvent OnWeaponsEnabled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnWeaponsDisabled?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnWeaponsEnabled?.Invoke();
        }
    }
}
