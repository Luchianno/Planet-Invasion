using System.Collections;
using System.Collections.Generic;
using ScreenMgr;
using UnityEngine;
using Zenject;
using System;
using System.Linq;
using UnityEngine.UI;
using DG.Tweening;

public class ReportsScreen : ScaleAnimatedScreen
{
    [Space]
    public ReportsView reportsView;

    public Button Close;

    [Inject]
    PlanetState state;

    void Start()
    {
        Close.onClick.AddListener(screenManager.Hide);
    }
    
    public override void OnShow()
    {
        var thisTurnEvents = state.EventLog.Entries.Where(x => x.Turn == (state.Turn - 1));

        reportsView.Init(thisTurnEvents);
    }

}
