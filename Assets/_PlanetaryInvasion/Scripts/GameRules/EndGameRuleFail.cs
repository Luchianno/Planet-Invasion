using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "PI/Rules/Fail By ")]
public class EndGameRuleFail : ScriptableGameRule
{
    public override bool Check(PlanetState state)
    {
        var player = state.Player;
        if (!state.Player.Resources.TryGetValue(Resource.AllResources["Ships"], out var amount)
            || amount <= 0)
        {
            return true;
        }

        return false;
    }
}
