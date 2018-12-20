using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EndGameState : GameState
{
    [Inject(Id = "endgame")]
    Canvas canvas;

    // [Inject]
    // CameraPositionController cameraPositionController;

    [Inject]
    EndGameView view;

    // public string EndGameText = "Game Has Ended";
    // public Sprite EndGameImage;

    [Inject]
    PlanetState state;

    public override void OnEnter()
    {
        canvas.enabled = true;
        // cameraPositionController.ChangePos(CameraPositionController.CameraPosition.Map);
        // view.Init("You Won", EndGameText, EndGameImage);
    }

    // public virtual void Update() { }

    public override void OnExit()
    {
        canvas.enabled = false;
    }

    
    public override void Initialize()
    {
        canvas.enabled = false;
    }

}
