using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using System.Collections.ObjectModel;

public class PlanetStateController : MonoBehaviour
{
    public UnityEvent StepProcessStarted;
    public UnityEvent StepProcessCompleted;

    public ReadOnlyCollection<Card> PlayerSelectedCards { get { return state.Player.SelectedCards.AsReadOnly(); } }

    public ReadOnlyCollection<Card> AISelectedCards { get { return state.AI.SelectedCards.AsReadOnly(); } }


    [Inject]
    StoryController storyController;
    [Inject]
    PlanetState state;
    [Inject]
    UpdateableViewManager viewsManager;

    void Start()
    {
        viewsManager.UpdateViews();
    }

    public void AddPlayerAction(Card card)
    {
        state.Player.SelectedCards.Add(card);
        viewsManager.UpdateViews();
    }

    public void RemovePlayerAction(Card card)
    {
        state.Player.SelectedCards.Remove(card);
        viewsManager.UpdateViews();
    }

    public void Step()
    {
        StepProcessStarted.Invoke();

        #region Pre Process

        foreach (var item in AISelectedCards)
        {
            var diff = item.PreProcess(TurnState.AITurn, this.state);
            state = diff.FinalState;
        }

        foreach (var item in state.Player.SelectedCards)
        {
            var diff = item.PreProcess(TurnState.PlayerTurn, this.state);
            state = diff.FinalState;
        }

        #endregion

        #region Process USE ONLY THIS FOR NOW

        foreach (var item in AISelectedCards)
        {
            var diff = item.Process(TurnState.AITurn, this.state);
            state = diff.FinalState;
        }

        foreach (var item in state.Player.SelectedCards)
        {
            var diff = item.Process(TurnState.PlayerTurn, this.state);
            if (!string.IsNullOrEmpty(diff.Message))
            {
                state.Story.Stories.Add(new StoryLog.StoryLogEntry()
                {
                    Turn = state.Turn,
                    Text = diff.Message,
                    Type = diff.MessageType
                });
            }
            state = diff.FinalState;
        }

        #endregion

        #region After Process

        foreach (var item in AISelectedCards)
        {
            var diff = item.AfterProcess(TurnState.AITurn, this.state);
            state = diff.FinalState;
        }

        foreach (var item in state.Player.SelectedCards)
        {
            var diff = item.AfterProcess(TurnState.PlayerTurn, this.state);
            state = diff.FinalState;
        }

        #endregion

        foreach (var item in ScriptableObjectTools<StoryEntry>.All)
        {
            if (item.ShouldActivate(state.Player))
                storyController.AddStory(item);
        }

        state.Player.SelectedCards.Clear();
        state.AI.SelectedCards.Clear();

        state.Turn++;
        StepProcessCompleted.Invoke();
        viewsManager.UpdateViews();
    }

    // public void foo(ProcessAction action)
    // {
    //     var temp = typeof(Card);
    //     var method = temp.GetMethod("Process");
    //     action.Invoke()
    //     foreach (var item in AISelectedCards)
    //     {
    //         var diff = item.AfterProcess(TurnState.AITurn, this.state);
    //         state = diff.FinalState;
    //     }

    //     foreach (var item in state.Player.SelectedCards)
    //     {
    //         var diff = item.AfterProcess(TurnState.PlayerTurn, this.state);
    //         state = diff.FinalState;
    //     }
    // }

    // delegate void ProcessAction(TurnState turnState, GameState state);
}
