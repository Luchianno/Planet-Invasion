using System.Collections;
using System.Collections.Generic;
using ScreenMgr;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

public class HangarScreen : BaseScreen
{
    public Button MissionControl;
    public Button OpenArchive;
    public Button Reports;

    [Inject]
    CameraPositionController cameraPositionController;

    void Start()
    {
        OpenArchive.onClick.AddListener(() =>
        screenManager.ShowPopup<ArchivePopup>("ArchivePopup")
        );

        MissionControl.onClick.AddListener(() => screenManager.Hide());

        Reports.onClick.AddListener(() => screenManager.ShowScreen("ReportsScreen"));
    }

    public override void OnAnimationIn()
    {
        cameraPositionController.ChangePos(CameraPositionController.CameraPosition.Hangar);
        cameraPositionController.CameraMovementComplete.AddListener(OnComplete);
    }

    void OnComplete()
    {
        cameraPositionController.CameraMovementComplete.RemoveListener(OnComplete);
        OnAnimationInEnd();
    }
}
