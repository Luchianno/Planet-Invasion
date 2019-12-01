using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Zenject;
using ScreenMgr;

[CreateAssetMenu(menuName = "PI/Rules/Win Game by Genocide")]
public class EndGameRule1 : ScriptableGameRule
{
    public Sprite EndGameImage;
    public int MinPopulation = 2;

    [Inject]
    ScreenManager screenManager;

    public override bool Check(PlanetState state)
    {
        var ai = state.AI;
        var result = ai.CountryStates.TrueForAll(x => x.Population <= MinPopulation);
        if (result)
        {
            screenManager.ShowPopup<EndGameScreen>("EndgameScreen").Init(Title, Description, null);
            // view.Init("You Won", this.Description, this.EndGameImage);
        }
        return result;
    }

}
