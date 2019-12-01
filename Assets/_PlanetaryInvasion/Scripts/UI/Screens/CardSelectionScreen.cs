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
        ToMap.onClick.AddListener(() => screenManager.Hide());//ShowScreen("MapScreen"));
        Launch.onClick.AddListener(OnLaunch);
        // I2.Loc.LocalizationManager.GetTermData("").
    }

    public override void OnAnimationIn()
    {
        cameraPositionController.ChangePos(CameraPositionController.CameraPosition.MissionControl);
        cameraPositionController.CameraMovementComplete.AddListener(OnComplete);
    }

    void OnComplete()
    {
        cameraPositionController.CameraMovementComplete.RemoveListener(OnComplete);
        OnAnimationInEnd();
    }

    void OnLaunch()
    {
        planetStateController.Step();
        screenManager.ShowPopup<ReportsScreen>("ReportsScreen");
        // screenManager.HideAllAndShow("MapScreen");
    }

}
