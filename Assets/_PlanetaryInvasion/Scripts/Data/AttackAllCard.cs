using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PI/Actions/Attack All")]
public class AttackAllCard : Card
{
    public IntRange StrengthDamage;
    public IntRange PopDamage;
    public IntRange TerrorDamage;

    [TextArea]
    public string SuccessText;
    [TextArea]
    public string FailText;

    public string TargetCountry;

    public override ActionResult Process(TurnState turn, PlanetState state)
    {
        state.AI.CountryStates.ForEach(temp =>
       {
           temp.MilitaryStrength -= StrengthDamage.GetRandom();
           temp.Population -= PopDamage.GetRandom();
           temp.Terror += TerrorDamage.GetRandom();
       });

        state.EventLog.Entries.Add(new StoryLogEntry()
        {
            Card = this,
            SuccessType = ActionResultType.Success,
            Turn = state.Turn,
            Text = SuccessText,
            Type = StoryLogEntryType.CardResult
        });

        return new ActionResult()
        {
            FinalState = state,
            Message = SuccessText,
            Type = ActionResultType.Success,
        };
    }
}
