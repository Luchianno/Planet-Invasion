using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PI/Gather Resources Card")]
public class GatherResourceCard : Card
{
    [Space]
    [Header("--Card Specific--")]
    [Space]
    public Resource GatheredResource;
    public int Amount;

    public string CompletionText = "{Resource} Gathered";

    public string GetCompletionText()
    {
        return CompletionText.Replace("{Resource}", GatheredResource.Name);
    }

    public override ActionResult Process(TurnState turn, PlanetState state)
    {
        var temp = turn == TurnState.PlayerTurn ? state.Player : state.AI;

        // TODO Failsafe?..
        if (!temp.Resources.ContainsKey(GatheredResource))
        {
            temp.Resources.Add(GatheredResource, 0);
        }
        temp.Resources[GatheredResource] += Amount;
        return new ActionResult() { Type = ActionResultType.Success, FinalState = state, Message = CompletionText };
    }
}