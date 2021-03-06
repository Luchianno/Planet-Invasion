using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "PI/Gather Resources Card")]
public class GatherResourceCard : Card
{
    [Space]
    [Header("--Card Specific--")]
    [Space]
    public ResourceDictionary PlayerResourceChange;
    [Space]
    public ResourceDictionary AIResourceChange;

    [Header("{amount} {resource}")]
    [TextArea]
    public string CompletionText = "{amount} {resource} Gathered";

    public string GetCompletionText()
    {
        var builder = new StringBuilder();
        foreach (var item in PlayerResourceChange)
        {
            builder.AppendLine(CompletionText.Replace("{resource}", item.Key.Name).Replace("{amount}", item.Value.ToString()));
        }
        return builder.ToString();
    }

    public override ActionResult Process(TurnState turn, PlanetState state)
    {
        state.AI.Resources.AddResources(AIResourceChange);
        state.Player.Resources.AddResources(PlayerResourceChange);
        state.EventLog.Entries.Add(new StoryLogEntry()
        {
            Card = this,
            SuccessType = ActionResultType.Success,
            Turn = state.Turn,
            Text = GetCompletionText(),
            Type = StoryLogEntryType.CardResult,
            IsPlayerAction = turn == TurnState.PlayerTurn
        });

        // TODO Failsafe?..
        // if (!temp.Resources.ContainsKey(GatheredResource))
        // {
        //     temp.Resources.Add(GatheredResource, 0);
        // }
        // temp.Resources[GatheredResource] += Amount;
        return new ActionResult() { Type = ActionResultType.Success, FinalState = state, Message = GetCompletionText() };
    }
}