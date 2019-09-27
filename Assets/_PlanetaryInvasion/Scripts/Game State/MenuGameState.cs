using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuGameState : GameState, IInitializable
{
    // [Inject]
    // MenuView view;
    [Inject]
    GameStateMachine sm;

    public override void Initialize()
    {
        // view.OnStartClicked.AddListener(() =>
        // {
        //     AI.enabled = false;
        //     sm.ChangeState<InGameState>();
        // });

        // view.OnStartAIClicked.AddListener(() =>
        // {
        //     AI.enabled = true;
        //     sm.ChangeState<InGameState>();
        // });
        // view.OnEggClicked.AddListener(() => Application.OpenURL("https://youtu.be/0XgCsv-y-mc?t=70"));
        // view.OnBackKeyClicked.AddListener(() => Application.Quit());
    }

    public override void OnEnter()
    {
        // view.enabled = true;
        // view.SetHighScore(scoreController.HighScore);
    }

    public override void OnExit()
    {
        // view.enabled = false;
    }
}