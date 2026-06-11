using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Zenject;
using Doozy.Runtime.UIManager.Containers;

[CreateAssetMenu(menuName = "PI/Rules/Win Game by Destruction")]
public class EndGameRule2 : ScriptableGameRule
{
    public Sprite EndGameImage;
    public int MinStrength = 1;

    public override bool Check(PlanetState state)
    {
        var ai = state.AI;
        var result = ai.CountryStates.TrueForAll(x => x.MilitaryStrength <= MinStrength);
        if (result)
        {
            var popup = UIPopup.Get("EndGame")
                .SetTexts(this.Title, this.Description);
                
            popup.Show();
        }
        return result;
    }

}
