using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.UI;
using UnityEngine;
using Zenject;
using System.Linq;

[CreateAssetMenu(menuName = "PI/Rules/Fail By Ships")]
public class EndGameRuleFail : ScriptableGameRule
{
    public override bool Check(PlanetState state)
    {
        var player = state.Player;
        var shipsResource = state.Player.Resources.Keys.First(x => x.Name == "Ships");

        state.Player.Resources.TryGetValue(shipsResource, out var amount);
        
        if (amount <= 0)
        {
            Debug.Log(this.Title);
            Debug.Log(this.Description);

            var popup = UIPopup.GetPopup("EndGame");
            popup.Data.SetLabelsTexts(this.Title, this.Description);
            popup.Data.Labels[0].GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
            popup.Show();
            return true;
        }

        return false;
    }
}
