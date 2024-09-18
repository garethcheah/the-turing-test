using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonPad : MonoBehaviour
{
    [SerializeField] private TMP_Text _textButtonPad;

    public void UpdateButtonPadMessage(string doorStatus)
    {
        _textButtonPad.text = doorStatus.ToString();
    }
}
