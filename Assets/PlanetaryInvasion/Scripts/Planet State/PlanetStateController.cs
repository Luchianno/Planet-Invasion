using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using System.Collections.ObjectModel;
using System.Linq;

public class PlanetStateController : MonoBehaviour
{
    public UnityEvent StepProcessStarted;
    public UnityEvent StepProcessCompleted;

    public ReadOnlyCollection<SelectedAction> PlayerSelectedCards { get { return state.Player.SelectedCards.AsReadOnly(); } }

    public ReadOnlyCollection<SelectedAction> AISelectedCards { get { return state.AI.SelectedCards.AsReadOnly(); } }

    [Inject]
    StoryController storyController;
    [Inject]
    PlanetState state;
    [Inject]
    UpdateableViewManager viewsManager;
    [Inject]
    List<IGameRule> gameRules;

    void Start()
    {
        viewsManager.UpdateViews();
    }

    public void AddPlayerAction(SelectedAction selectedAction)
    {
        if (!state.Player.Resources.RemoveResources(selectedAction.Card.ResourceRequirements))
        {
            Debug.LogWarning("Not enough Resources");
            return;
        }
        state.Player.SelectedCards.Add(selectedAction);
        viewsManager.UpdateViews();
    }

    public void RemovePlayerAction(Card card)
    {
        state.Player.SelectedCards.RemoveAll(x => x.Card == card);
        state.Player.Resources.AddResources(card.ResourceRequirements);
        viewsManager.UpdateViews();
    }

    public void Step()
    {
        StepProcessStarted.Invoke();

        #region Pre Process

        foreach (var item in AISelectedCards)
        {
            var diff = item.Card.PreProcess(TurnState.AITurn, this.state);
            state = diff.FinalState;
        }

        foreach (var item in state.Player.SelectedCards)
        {
            var diff = item.Card.PreProcess(TurnState.PlayerTurn, this.state);
            state = diff.FinalState;
        }

        #endregion

        #region Process USE ONLY THIS FOR NOW

        foreach (var item in AISelectedCards)
        {
            var diff = item.Card.Process(TurnState.AITurn, this.state);
            state = diff.FinalState;
        }

        foreach (var item in state.Player.SelectedCards)
        {
            var diff = item.Card.Process(TurnState.PlayerTurn, this.state);
            if (!string.IsNullOrEmpty(diff.Message))
            {
                state.Story.Stories.Add(new GameEventLog.StoryLogEntry()
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
            var diff = item.Card.AfterProcess(TurnState.AITurn, this.state);
            state = diff.FinalState;
        }

        foreach (var item in state.Player.SelectedCards)
        {
            var diff = item.Card.AfterProcess(TurnState.PlayerTurn, this.state);
            state = diff.FinalState;
        }

        #endregion

        foreach (var item in ScriptableObjectTools<StoryEntry>.All)
        {
            if (item.ShouldActivate(state.Player))
                storyController.AddStory(item);
        }

        gameRules.ForEach(x => x.Check(state));

        state.Player.SelectedCards.Clear();
        state.AI.SelectedCards.Clear();

        state.Turn++;
        StepProcessCompleted.Invoke();
        viewsManager.UpdateViews();
    }

}
