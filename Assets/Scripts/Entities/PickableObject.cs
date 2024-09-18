using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour, IPickable
{
    private Rigidbody _rbPickUp;

    public void OnDropped()
    {
        _rbPickUp.isKinematic = false;
        _rbPickUp.useGravity = true;
        transform.SetParent(null);
    }

    public void OnPicked(Transform attachPoint)
    {
        transform.position = attachPoint.position;
        transform.rotation = attachPoint.rotation;
        transform.SetParent(attachPoint);

        _rbPickUp.isKinematic = true;
        _rbPickUp.useGravity = false;
    }

    private void Start()
    {
        _rbPickUp = GetComponent<Rigidbody>();
    }
}
