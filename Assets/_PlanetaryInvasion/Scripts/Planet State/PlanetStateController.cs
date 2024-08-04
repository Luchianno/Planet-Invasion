using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using Doozy.Engine;
using Doozy.Engine.UI;

public class PlanetStateController : MonoBehaviour
{
    public event Action StepProcessStarted;
    public event Action StepProcessCompleted;

    public ReadOnlyCollection<SelectedAction> PlayerSelectedCards => state.Player.SelectedCards.AsReadOnly();

    public ReadOnlyCollection<SelectedAction> AISelectedCards => state.AI.SelectedCards.AsReadOnly();

    [Inject]
    StoryController storyController;
    [Inject]
    [SerializeField]
    PlanetState state;
    [Inject]
    UpdateableViewManager viewsManager;
    [Inject]
    List<IGameRule> gameRules;

    void Start()
    {
        viewsManager.UpdateViews();
        GameEventMessage.AddListener("LaunchClicked", Step);
    }

    public void AddPlayerAction(SelectedAction selectedAction)
    {
        if (state.Player.SelectedCards.Count >= 3)
        {
            Debug.LogWarning("All action slots taken");
            return;
        }
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

    public void AddAIAction(SelectedAction selectedAction)
    {
        if (!state.AI.Resources.RemoveResources(selectedAction.Card.ResourceRequirements))
        {
            Debug.LogWarning("Not enough AI Resources");
            return;
        }
        state.AI.SelectedCards.Add(selectedAction);
        viewsManager.UpdateViews();
    }

    public void Step()
    {
        StepProcessStarted?.Invoke();

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
            var temp = item.Card as AttackCountryCard;

            if (temp != null)
            {
                temp.TargetCountry = item.Country.Name;
            }

            var actionResult = item.Card.Process(TurnState.PlayerTurn, this.state);

            // if (!string.IsNullOrEmpty(actionResult.Message))
            // {
            //     state.EventLog.Entries.Add(new StoryLogEntry()
            //     {
            //         Turn = state.Turn,
            //         Text = actionResult.Message,
            //         Type = actionResult.MessageType,
            //         SuccessType = actionResult.Type,
            //     });
            // }
            state = actionResult.FinalState;
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

        // process game rules
        gameRules.ForEach(x => x.Check(state));

        state.Player.SelectedCards.Clear();
        state.AI.SelectedCards.Clear();

        state.Turn++;
        StepProcessCompleted?.Invoke();
        viewsManager.UpdateViews();

    }

}
