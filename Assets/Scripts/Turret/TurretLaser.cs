using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretLaser : MonoBehaviour
{
    public UnityEvent OnTargetHit;

    [SerializeField] private Transform _laserOriginPoint;
    [SerializeField] private float _maxDistance = 20.0f;
    [SerializeField] private Material _disabledColor;
    [SerializeField] private string _targetTag;

    private MeshRenderer _renderer;
    private LineRenderer _laser;
    private RaycastHit _rayCastHit;
    private Ray _ray;
    private bool _enabled;

    public void ActivateLaser()
    {
        _enabled = true;
    }

    public void DeactivateLaser()
    {
        _enabled = false; 
    }

    public void DisplayDisabledColor()
    {
        Material[] materials = _renderer.materials;
        materials[1] = _disabledColor;
        _renderer.materials = materials;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _laser = GetComponent<LineRenderer>();
        _enabled = false;
        _laser.enabled = _enabled;
    }

    // Update is called once per frame
    private void Update()
    {
        _laser.enabled = _enabled;

        if (_enabled)
        {
            _ray = new Ray(_laserOriginPoint.position, _laserOriginPoint.forward);

            if (Physics.Raycast(_ray, out _rayCastHit, _maxDistance))
            {
                _laser.SetPosition(0, _laserOriginPoint.position);
                _laser.SetPosition(1, _rayCastHit.point);

                if (_rayCastHit.collider.CompareTag(_targetTag))
                {
                    OnTargetHit?.Invoke();
                }
            }
            else
            {
                _laser.SetPosition(0, _laserOriginPoint.position);
                _laser.SetPosition(1, _laserOriginPoint.position + _laserOriginPoint.forward * _maxDistance);
            }
        }

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(_laserOriginPoint.position, _laserOriginPoint.forward * _maxDistance);
    //}
}
