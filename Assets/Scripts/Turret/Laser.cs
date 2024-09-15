using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform _laserOriginPoint;
    [SerializeField] private float _maxDistance = 10.0f;
    [SerializeField] private UnityEvent OnHitTarget;

    private LineRenderer _lineRenderer;
    private RaycastHit _rayCastHit;
    private Ray _ray;

    // Start is called before the first frame update
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        _ray = new Ray(_laserOriginPoint.position, _laserOriginPoint.forward);

        if (Physics.Raycast(_ray, out _rayCastHit, _maxDistance))
        {
            _lineRenderer.SetPosition(0, _laserOriginPoint.position);
            _lineRenderer.SetPosition(1, _rayCastHit.point);

            if (_rayCastHit.collider.CompareTag("Player"))
            {
                Debug.Log("Player is hit.");
                OnHitTarget?.Invoke();
            }
        }
        else
        {
            _lineRenderer.SetPosition(0, _laserOriginPoint.position);
            _lineRenderer.SetPosition(1, _laserOriginPoint.position + _laserOriginPoint.forward * _maxDistance);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(_laserOriginPoint.position, _laserOriginPoint.forward * _maxDistance);
    //}
}
