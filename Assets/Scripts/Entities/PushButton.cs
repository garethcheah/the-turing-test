using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, ISelectable
{
    public UnityEvent OnPush;

    [SerializeField] private Material _hoverColor;
    [SerializeField] private Material _enabledColor;

    private Material _defaultColor;
    private Material _disabledColor;
    private MeshRenderer _renderer;

    public void OnHoverEnter()
    {
        _renderer.material = _hoverColor;
    }

    public void OnHoverExit()
    {
        _renderer.material = _defaultColor;
    }

    public void DisplayDisabledColor()
    {
        Material[] materials = _renderer.materials;
        materials[1] = _disabledColor;
        _renderer.materials = materials;
    }

    public void DisplayEnabledColor()
    {
        Material[] materials = _renderer.materials;
        materials[1] = _enabledColor;
        _renderer.materials = materials;
    }

    public void OnSelect()
    {
        OnPush?.Invoke();
    }

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _defaultColor = _renderer.material;
        _disabledColor = _renderer.materials[1];
    }
}
