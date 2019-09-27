using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller<MainInstaller>
{
    [SerializeField]
    PlanetStateController stateController;

    [SerializeField]
    GameSettings settings;

    [SerializeField]
    TabPanelView storyView;

    [SerializeField]
    PlanetState startingState;

    [Space]
    [Header("Prefabs to factories")]
    [SerializeField]
    GameObject tabletPrefab;

    [Space]
    [SerializeField]
    Canvas inGameCanvas;
    [SerializeField]
    Canvas mapCanvas;
    [SerializeField]
    Canvas endGameCanvas;
    [SerializeField]
    Canvas hangarCanvas;


    public override void InstallBindings()
    {
        Container.BindInstance<GameSettings>(settings);

        Container.BindInterfacesAndSelfTo<PlanetState>().FromInstance(startingState).AsSingle();
        Container.BindInterfacesAndSelfTo<StoryController>().AsSingle();

        Container.BindInstance<PlanetStateController>(stateController);
        Container.Bind<UpdateableViewManager>().AsSingle();

        // views
        Container.Bind<IUpdateableView>().To<AllActionsView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<IUpdateableView>().To<SelectedActionsView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<IUpdateableView>().To<ResourcesView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<IUpdateableView>().To<TechView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<IUpdateableView>().To<EventLogView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<IUpdateableView>().To<EventLogView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<IUpdateableView>().To<CountryView>().FromComponentsInHierarchy(includeInactive: true);

        Container.Bind<EndGameView>().FromComponentsInHierarchy(includeInactive: true);

        Container.Bind<TargetSelectionView>().FromComponentsInHierarchy(includeInactive: true);
        Container.BindInstance<TabPanelView>(storyView).WithId("story").AsSingle();

        // canvases 
        Container.BindInstance<Canvas>(inGameCanvas).WithId("inGame");
        Container.BindInstance<Canvas>(mapCanvas).WithId("map");
        Container.BindInstance<Canvas>(endGameCanvas).WithId("endgame");
        Container.BindInstance<Canvas>(hangarCanvas).WithId("hangar");

        // game states
        Container.Bind<IUpdateableView>().To<CountryView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<GameStateMachine>().FromComponentInHierarchy(includeInactive: true).AsSingle();

        // Container.Bind(typeof(IInitializable), typeof(GameState)).To<MenuGameState>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(GameState)).To<HQGameState>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(GameState)).To<TargetSelectionGameState>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(GameState)).To<EndGameState>().AsSingle();
        Container.Bind(typeof(IInitializable), typeof(GameState)).To<HangarGameState>().AsSingle();

        Container.Bind<CameraPositionController>().FromComponentsInHierarchy(includeInactive: true);

        // factories
        Container.BindFactory<TabletView, TabletView.Factory>().FromComponentInNewPrefab(tabletPrefab);

        Application.targetFrameRate = 60;
    }
}