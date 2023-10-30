using Helpers;
using Infrustructure.Factory;
using Infrustructure.Services.Input;
using Infrustructure.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using BodyPartsMovement = Logic.Snake.Controllers.BodyPartsMovement;
using BootstrapState = Infrustructure.StateMachine.BootstrapState;
using IBodyPartsMovement = Logic.Snake.Interfaces.IBodyPartsMovement;
using IGameStateMachine = Infrustructure.StateMachine.IGameStateMachine;
using IPlayerMovement = Logic.Snake.Interfaces.IPlayerMovement;
using LoadLevelState = Infrustructure.StateMachine.LoadLevelState;
using PlayerController = Logic.Snake.Controllers.PlayerController;
using PlayerModel = Logic.Snake.Models.PlayerModel;
using PlayerMovement = Logic.Snake.Controllers.PlayerMovement;

namespace Infrustructure.Installers
{
    public class RootScope : LifetimeScope
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;

        protected override void Configure(IContainerBuilder builder)
        {
            DontDestroyOnLoad(this);
            builder.Register<PrefabInject>(Lifetime.Singleton);
            builder.RegisterComponentInNewPrefab<CoroutineRunner>(_coroutineRunner,Lifetime.Singleton).DontDestroyOnLoad().AsImplementedInterfaces();
            InstallGameStateMachine(builder);
            builder.Register<SceneLoader>(Lifetime.Singleton);
            builder.Register<StandaloneInputService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<MobileInputService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameObjectFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            InstallGameObjects(builder);
            builder.RegisterEntryPoint<RootEntryPoint>();
            builder.RegisterEntryPoint<GameLoopState>();

        }

        private void InstallGameStateMachine(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton).As<IGameStateMachine>().AsSelf();
            builder.Register<BootstrapState>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<LoadLevelState>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<GameLoopState>(Lifetime.Scoped).AsImplementedInterfaces();
        }

        private void InstallGameObjects(IContainerBuilder builder)
        {
            builder.Register<BodyPartsMovement>(Lifetime.Singleton).As<IBodyPartsMovement>().AsSelf();
            builder.Register<PlayerModel>(Lifetime.Singleton);
            
            builder.Register<PlayerMovement>(Lifetime.Singleton).As<IPlayerMovement>().AsSelf();
            builder.Register<PlayerController>(Lifetime.Singleton).AsSelf();
        }

    }

public class RootEntryPoint : IStartable
{
[Inject] private GameStateMachine _gameStateMachine;
public void Start()
{
    _gameStateMachine.Enter<LoadLevelState,string>(Constants._gameSceneName);
}




}
}