using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;

public class AIPlayer : MonoBehaviour
{
    [Inject]
    protected PlanetStateController planetStateController;

    public Card AttackCard;
    public Card GenerateMoney;

    public void Think(PlanetState state)
    {
        /*
        if enough resources
            attack
        else 
            generate money

        */
        var money = state.AI.Resources.Keys.First(x => x.Name == "Money");
        if (state.AI.Resources[money] >= 30)
        {
            planetStateController.AddAIAction(new SelectedAction()
            {
                Card = AttackCard
            });
        }
        else
        {
            planetStateController.AddAIAction(new SelectedAction()
            {
                Card = GenerateMoney
            });
        }
    }

    public List<Card> Add(PlanetState state)
    {
        // foreach 
        return null;


    }
}
