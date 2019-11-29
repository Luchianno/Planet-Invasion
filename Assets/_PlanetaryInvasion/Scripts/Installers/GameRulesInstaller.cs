using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameRulesInstaller : MonoInstaller<GameRulesInstaller>
{
    [SerializeField]
    List<ScriptableGameRule> gameRules;

    public override void InstallBindings()
    {
        var temp1 = Container.InstantiateScriptableObjectResource<ScriptableGameRule>(@"Rules/EnGame Strength");
        var temp2 = Container.InstantiateScriptableObjectResource<ScriptableGameRule>(@"Rules/EndGame Population");
        Debug.Log(temp1);
        Debug.Log(temp2);
        Container.BindInstance<IGameRule>(temp1);
        Container.BindInstance<IGameRule>(temp2);
        // foreach (var item in gameRules)
        // {
        //     Container.BindInstance<IGameRule>(temp);
        // }
    }
}