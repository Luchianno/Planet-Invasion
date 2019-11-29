using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Zenject;

[CreateAssetMenu(menuName = "PI/Rules/Win Game by Genocide")]
public class EndGameRule1 : ScriptableGameRule
{
    [TextArea(3, 10)]
    public string Description;
    public Sprite EndGameImage;
    public int MinPopulation = 2;

    public override bool Check(PlanetState state)
    {
        var ai = state.AI;
        var result = ai.CountryStates.TrueForAll(x => x.Population <= MinPopulation);
        if (result)
        {
            // view.Init("You Won", this.Description, this.EndGameImage);
        }
        return result;
    }

}
