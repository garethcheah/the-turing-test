using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePadController : MonoBehaviour
{
    public UnityEvent OnTriggerSucceeded;
    public UnityEvent OnTriggerFailed;

    [SerializeField] PressurePad[] pressurePads;

    public void CheckPressurePads()
    {
        bool isAllActivated = true;

        foreach (PressurePad pressurePad in pressurePads)
        {
            if (!pressurePad.IsActivated())
            {
                isAllActivated = false;
                break;
            }
        }

        if (isAllActivated)
        {
            OnTriggerSucceeded?.Invoke();
        }
        else
        {
            OnTriggerFailed?.Invoke();
        }
    }
}
