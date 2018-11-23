using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller<MenuInstaller>
{
    [SerializeField]
    GameObject musicManager;

    public override void InstallBindings()
    {
        // Container.Bind<MusicController>().FromComponentInNewPrefab(musicManager).AsSingle();
        Container.InstantiatePrefabForComponent<MusicController>(musicManager);
    }
}