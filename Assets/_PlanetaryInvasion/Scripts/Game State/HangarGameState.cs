using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HangarGameState : GameState
{
    [Inject(Id = "hangar")]
    Canvas canvas;

    [Inject]
    CameraPositionController cameraPositionController;

    public override void Initialize()
    {
        canvas.enabled = false;
    }

    public override void OnEnter()
    {
        canvas.enabled = true;
        cameraPositionController.ChangePos(CameraPositionController.CameraPosition.Hangar);
    }

    public override void OnExit()
    {
        canvas.enabled = false;
    }

}
