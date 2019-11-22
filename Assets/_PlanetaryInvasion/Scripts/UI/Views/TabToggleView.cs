using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[RequireComponent(typeof(Toggle))]
public class TabToggleView : MonoBehaviour
{
    [SerializeField]
    protected Toggle Toggle;
    [SerializeField]
    protected TextMeshProUGUI Label;

    public event Action<TabToggleView, bool> OnValueChanged;

    void Awake()
    {
        Toggle = GetComponent<Toggle>();
        Toggle.onValueChanged.AddListener((value) => OnValueChanged?.Invoke(this, value));
    }

    public void Init(string value, ToggleGroup group)
    {
        Label.text = value;

        Toggle.isOn = false;
        Toggle.group = group;
    }
}
