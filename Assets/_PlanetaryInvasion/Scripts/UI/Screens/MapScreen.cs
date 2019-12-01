using System.Collections;
using System.Collections.Generic;
using ScreenMgr;
using UnityEngine;
using Zenject;

public class MapScreen : BaseScreen
{
    [Inject]
    CameraPositionController cameraPositionController;

    public GameObject MapCanvasObject;


    public override void OnShow()
    {
        MapCanvasObject.SetActive(true);
    }

    public override void OnHide()
    {
        MapCanvasObject.SetActive(false);
    }

    public override void OnAnimationIn()
    {
        cameraPositionController.ChangePos(CameraPositionController.CameraPosition.Map);
        cameraPositionController.CameraMovementComplete.AddListener(OnComplete);
    }

    void OnComplete()
    {
        cameraPositionController.CameraMovementComplete.RemoveListener(OnComplete);
        OnAnimationInEnd();
    }
}
