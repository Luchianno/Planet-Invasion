using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "PI/Actions/Attack Country")]
public class AttackCountryCard : Card
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
        var temp = state.AI.CountryStates.Find(x => x.Name == TargetCountry);
        temp.MilitaryStrength -= StrengthDamage.GetRandom();
        temp.Population -= PopDamage.GetRandom();
        temp.Terror += TerrorDamage.GetRandom();

        // state.
        return new ActionResult()
        {
            FinalState = state,
            Message = SuccessText,
            Type = ActionResultType.Success
        };
    }
}
