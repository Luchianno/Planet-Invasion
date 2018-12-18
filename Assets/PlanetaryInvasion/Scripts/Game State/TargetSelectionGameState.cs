﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TargetSelectionGameState : GameState
{
    [Inject(Id = "map")]
    Canvas canvas;

    [Inject]
    CameraPositionController cameraPositionController;

    public override void OnEnter()
    {
        canvas.enabled = true;
        cameraPositionController.ChangePos(CameraPositionController.CameraPosition.Map);
    }

    // public virtual void Update() { }

    public override void OnExit()
    {
        canvas.enabled = false;
    }

}
