using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Engine.UI;
using Zenject;
using System.Linq;

[RequireComponent(typeof(Button))]
public class OpenPopupOnClick : MonoBehaviour
{
    Button button;

    public string PopupName;

    [Inject]
    protected PlanetState state;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        var popup = UIPopup.GetPopup(PopupName);

        // var info = state.EventLog.Entries.Where(x => x.Turn == state.Turn);

        // Debug.Log(popup == null);
        // Debug.Log(popup.GetComponentInChildren<ReportsView>() == null);

        // popup.GetComponentInChildren<ReportsView>().Init(info);
        popup.Show();
    }

}
