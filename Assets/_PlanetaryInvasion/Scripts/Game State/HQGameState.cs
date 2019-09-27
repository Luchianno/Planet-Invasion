using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HQGameState : GameState
{
    [Inject(Id = "inGame")]
    Canvas canvas;

    [Inject]
    CameraPositionController cameraPositionController;

    public override void Initialize()
    {
        canvas.enabled = true;
    }

    public override void OnEnter()
    {
        canvas.enabled = true;
        cameraPositionController.ChangePos(CameraPositionController.CameraPosition.MissionControl);
    }

    public override void OnExit()
    {
        canvas.enabled = false;
    }
}
