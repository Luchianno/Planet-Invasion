using System.Collections.Generic;
using System.Linq;
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

    [SerializeField]
    protected List<CountryState> Countries;

    public override void InstallBindings()
    {
        Container.BindInstance<GameSettings>(settings);

        var PlanetState = Instantiate(startingState);
        PlanetState.AI.CountryStates.Clear();
        PlanetState.AI.CountryStates.AddRange(Countries.Select(x => Instantiate(x)));

        Container.BindInterfacesAndSelfTo<PlanetState>().FromInstance(PlanetState).AsSingle();


        Container.BindInterfacesAndSelfTo<StoryController>().AsSingle();

        Container.BindInstance<PlanetStateController>(stateController).AsSingle();
        Container.Bind<UpdateableViewManager>().AsSingle();

        // views
        Container.Bind<IUpdateableView>().To<AllActionsView>().FromComponentsInHierarchy(includeInactive: true).AsSingle();
        Container.Bind<IUpdateableView>().To<SelectedActionsView>().FromComponentsInHierarchy(includeInactive: true).AsSingle();
        Container.Bind<IUpdateableView>().To<ResourcesView>().FromComponentsInHierarchy(includeInactive: true).AsSingle();
        Container.Bind<IUpdateableView>().To<TechView>().FromComponentsInHierarchy(includeInactive: true).AsSingle();
        Container.Bind<IUpdateableView>().To<EventLogView>().FromComponentsInHierarchy(includeInactive: true).AsSingle();
        Container.Bind<IUpdateableView>().To<CountryView>().FromComponentsInHierarchy(includeInactive: true).AsSingle();

        Container.Bind<EndGameView>().FromComponentsInHierarchy(includeInactive: true).AsSingle();

        Container.BindInstance<TabPanelView>(storyView).WithId("story").AsSingle();

        // Container.Bind<ScreenManager>().FromComponentInHierarchy(true).AsSingle();
        Container.Bind<CameraPositionController>().FromComponentsInHierarchy(includeInactive: true).AsSingle();

        // factories
        Container.BindFactory<TabletView, TabletView.Factory>().FromComponentInNewPrefab(tabletPrefab);
        // Container.BindFactory<Object, BaseScreen, BaseScreen.Factory>().FromFactory<PrefabFactory<BaseScreen>>();

        Application.targetFrameRate = 60;
    }
}