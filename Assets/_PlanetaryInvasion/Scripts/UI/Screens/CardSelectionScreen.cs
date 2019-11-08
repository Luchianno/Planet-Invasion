using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScreenMgr;
using UnityEngine.UI;
using Zenject;

public class CardSelectionScreen : BaseScreen
{
    public Button ToHangar;
    public Button ToMap;
    public Button Launch;

    [Inject]
    CameraPositionController cameraPositionController;

    [Inject]
    PlanetStateController planetStateController;

    void Start()
    {
        ToHangar.onClick.AddListener(() => screenManager.ShowScreen("HangarScreen"));
        ToMap.onClick.AddListener(() => screenManager.ShowScreen("MapScreen"));
        Launch.onClick.AddListener(OnLaunch);
    }

    public override void OnAnimationIn()
    {
        cameraPositionController.ChangePos(CameraPositionController.CameraPosition.MissionControl);
        OnAnimationInEnd();
    }

    void OnLaunch()
    {
        planetStateController.Step();
        screenManager.ShowScreen("ReportsScreen");
    }

}
