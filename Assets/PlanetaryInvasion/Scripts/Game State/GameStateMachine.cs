using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateMachine : MonoBehaviour, IInitializable, ITickable
{
    [Inject]
    List<GameState> states;

    GameState currentState;

    public void Initialize()
    {
        this.ChangeState<HQGameState>();
    }

    public void Tick()
    {
        if (currentState != null)
            currentState.Update();
    }

    public void ChangeState<T>() where T : GameState // just extra check during compile time, not to fuck up
    {
        Debug.Log($"Changing to state: {typeof(T)}");
        var state = states.Find(x => x.GetType() == typeof(T));
        if (state == null)
        {
            Debug.LogWarning("State not Found");
            return;
        }

        Debug.Log($"exiting current state: {currentState?.GetType().ToString()}");
        currentState?.OnExit();
        currentState = state;
        Debug.Log($"entering to state: {typeof(T)}");
        state.OnEnter();
    }

    public void ChangeState(State state)
    {
        switch (state)
        {
            case State.HQ:
                this.ChangeState<HQGameState>();
                break;
            case State.Hangar:
                this.ChangeState<HangarGameState>();
                break;
            case State.TargetSelection:
                this.ChangeState<TargetSelectionGameState>();
                break;
            case State.Map:
                this.ChangeState<MapOverviewGameState>();
                break;
            default:
                throw new NotImplementedException();
        }
    }

    public enum State
    {
        HQ, Hangar, TargetSelection, Map
    }
}