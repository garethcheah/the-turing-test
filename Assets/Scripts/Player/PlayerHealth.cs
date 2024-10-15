using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100.0f;

    public float _health;

    public Action<float> OnHealthUpdate;
    public Action OnDeath;

    public bool IsDead { get; private set; }

    public void DeductHealth(float value)
    {
        if (IsDead) return;

        _health -= value * Time.deltaTime;

        if (_health <= 0)
        {
            IsDead = true;
            OnDeath();
            _health = 0;
            GameManager.instance.ChangeState(GameManager.GameState.GameOver);
        }

        if (OnHealthUpdate != null)
            OnHealthUpdate(_health);
    }

    private void Start()
    {
        _health = _maxHealth;
        IsDead = false;

        if (OnHealthUpdate != null)
            OnHealthUpdate(_health);
    }
}
