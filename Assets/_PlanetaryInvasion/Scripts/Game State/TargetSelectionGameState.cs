using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TargetSelectionGameState : GameState
{
    // [Inject(Id = "map")]
    TargetSelectionView view;

    [Inject]
    CameraPositionController cameraPositionController;

    public override void Initialize()
    {
        
    }

    public override void OnEnter()
    {
        // canvas.enabled = true;
        cameraPositionController.ChangePos(CameraPositionController.CameraPosition.Map);
    }

    // public virtual void Update() { }

    public override void OnExit()
    {
        // canvas.enabled = false;
    }

}
