using System.Collections;
using System.Collections.Generic;
using ScreenMgr;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ArchivePopup : BaseScreen
{
    public Button Close;

    [SerializeField]
    protected Toggle toggle;

    public Toggle Toggle => toggle; // just discovered this, so FUCKING satisfying 

    public Toggle.ToggleEvent OnValueChanged;

    TabPanelView panelView;

    [Inject]
    PlanetState state;

    void Start()
    {
        Close.onClick.AddListener(() => screenManager.Hide());
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool value)
    {
        OnValueChanged.Invoke(value);
    }

    public override void OnShow()
    {
        
        // panelView.Init(state.Player);
    }

    public override void OnHide()
    {

    }
}
