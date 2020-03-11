using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Zenject;
using Doozy.Engine.UI;

[CreateAssetMenu(menuName = "PI/Rules/Win Game by Genocide")]
public class EndGameRule1 : ScriptableGameRule
{
    public Sprite EndGameImage;
    public int MinPopulation = 2;


    public override bool Check(PlanetState state)
    {
        var ai = state.AI;
        var result = ai.CountryStates.TrueForAll(x => x.Population <= MinPopulation);
        if (result)
        {
            var popup = UIPopup.GetPopup("EndGame");
            popup.Data.SetLabelsTexts(this.Title, this.Description);
            popup.Show();
        }
        return result;
    }

}
