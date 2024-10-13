using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    [SerializeField] private int numberOfCubesToActivate = 2;

    private int numberOfCubesOnPad;

    public bool IsActivated()
    {
        return numberOfCubesOnPad >= numberOfCubesToActivate;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pressure Cube"))
        {
            numberOfCubesOnPad++;

            if (numberOfCubesOnPad >= numberOfCubesToActivate)
            {
                OnActivate?.Invoke();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pressure Cube"))
        {
            numberOfCubesOnPad--;

            if (numberOfCubesOnPad < numberOfCubesToActivate)
            {
                OnDeactivate?.Invoke();
            }
        }
    }
}
