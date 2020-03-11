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
        var temp3 = Container.InstantiateScriptableObjectResource<ScriptableGameRule>(@"Rules/Fail");
        Container.BindInstance<IGameRule>(temp1);
        Container.BindInstance<IGameRule>(temp2);
        Container.BindInstance<IGameRule>(temp3);
        // foreach (var item in gameRules)
        // {
        //     Container.BindInstance<IGameRule>(temp);
        // }
    }
}