using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "PI/Actions/Attack Country")]
public class AttackCountryCard : Card
{
    public IntRange Damage;

    [TextArea]
    public string SuccessText;
    [TextArea]
    public string FailText;

    public string TargetCountry;

    public override ActionResult Process(TurnState turn, PlanetState state)
    {
        state.AI.CountryStates.Find(x => x.Name == TargetCountry);
        return new ActionResult()
        {
            FinalState = state,
            Message = SuccessText,
            Type = ActionResultType.Success
        };
    }
}
