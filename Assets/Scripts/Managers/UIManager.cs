using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private TMP_Text _textHealthValue;
    [SerializeField] private GameObject _textGameOver;
    [SerializeField] private GameObject _textGameEnd;
    [SerializeField] private GameObject _crosshair;

    public void OnGameEnd()
    {
        _crosshair.SetActive(false);
        _textGameEnd.SetActive(true);
    }

    private void Start()
    {
        _textGameOver.SetActive(false);
        _textGameEnd.SetActive(false);
        _crosshair.SetActive(true);
    }

    private void OnEnable()
    {
        // Add subscriptions
        _playerHealth.OnHealthUpdate += OnHealthUpdate;
        _playerHealth.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        // Remove subscriptions
        _playerHealth.OnHealthUpdate -= OnHealthUpdate;
    }

    private void OnHealthUpdate(float value)
    {
        _textHealthValue.text = Mathf.Floor(value).ToString();
    }

    private void OnDeath()
    {
        _crosshair.SetActive(false);
        _textGameOver.SetActive(true);
    }
}
