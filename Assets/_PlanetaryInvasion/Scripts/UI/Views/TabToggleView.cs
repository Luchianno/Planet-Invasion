using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabToggleView : MonoBehaviour
{
    [SerializeField]
    Text label;
    [SerializeField]
    Toggle toggle;

    public Toggle Toggle => toggle; // just discovered this, so FUCKING satisfying 

    public Toggle.ToggleEvent OnValueChanged;

    public void SetLabel(string content)
    {
        label.text = content;
    }

    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool value)
    {
        OnValueChanged.Invoke(value);
    }
}
