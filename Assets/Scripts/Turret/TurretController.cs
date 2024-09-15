using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private TurretMovement _turretMovement;
    [SerializeField] private TurretLaser _laser;
    [SerializeField] private float _attackRange = 10.0f;

    private Transform _target;
    private TurretState _currentState;

    public bool TargetIsInRange()
    {
        return _target != null && Vector3.Distance(_target.position, transform.position) <= _attackRange;
    }

    public void ChangeState(TurretState state)
    {
        _currentState.OnStateExit();
        _currentState = state;
        _currentState.OnStateEnter();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _currentState = new TurretIdleState(this, _target, _turretMovement, _laser);
        _currentState.OnStateEnter();
    }

    // Update is called once per frame
    private void Update()
    {
        _currentState.OnStateUpdate();
    }
}
