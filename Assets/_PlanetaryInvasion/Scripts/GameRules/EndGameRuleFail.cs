using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;
using Doozy.Runtime.UIManager.Containers;

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

            var popup = UIPopup.Get("EndGame");
            popup.SetTexts(this.Title, this.Description);
            // TODO fix
            popup.Labels[0].GetComponent<TMPro.TextMeshProUGUI>().color = Color.red;
            popup.Show();
            return true;
        }

        return false;
    }
}
