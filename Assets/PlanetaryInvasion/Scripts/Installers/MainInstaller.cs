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

    public override void InstallBindings()
    {
        Container.BindInstance<GameSettings>(settings);

        Container.BindInterfacesAndSelfTo<PlanetState>().FromInstance(startingState).AsSingle();
        Container.BindInterfacesAndSelfTo<StoryController>().AsSingle();

        Container.BindInstance<PlanetStateController>(stateController);
        Container.Bind<UpdateableViewManager>().AsSingle();

        Container.Bind<IUpdateableView>().To<AllActionsView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<IUpdateableView>().To<SelectedActionsView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<IUpdateableView>().To<ResourcesView>().FromComponentsInHierarchy(includeInactive: true);
        Container.Bind<IUpdateableView>().To<TechView>().FromComponentsInHierarchy(includeInactive: true);

        Container.BindInstance<TabPanelView>(storyView).WithId("story").AsSingle();
    }
}