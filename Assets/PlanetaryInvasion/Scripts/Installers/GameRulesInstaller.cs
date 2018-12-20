using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameRulesInstaller : MonoInstaller<GameRulesInstaller>
{
    [SerializeField]
    List<ScriptableGameRule> gameRules;

    public override void InstallBindings()
    {
        foreach (var item in gameRules)
        {
            Container.BindInstance<IGameRule>(item);
        }
    }
}