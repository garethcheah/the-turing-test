using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    [SerializeField] private bool isFalsePlatform;

    private Animator _floatingPlatformAnimator;
    public void CheckPlatform()
    {
        if (isFalsePlatform)
        {
            _floatingPlatformAnimator.SetBool("IsOpening", true);
        }
    }

    private void Start()
    {
        _floatingPlatformAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isFalsePlatform)
        {
            _floatingPlatformAnimator.SetTrigger("PlatformOpen");
        }
    }
}
