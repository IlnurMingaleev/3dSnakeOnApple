using System;
using System.Collections.Generic;
using Infrustructure.Factory;
using Logic.Snake.Controllers;

namespace Infrustructure.StateMachine
{
  public class GameStateMachine : IGameStateMachine
  {
    private Dictionary<Type, IExitableState> _states;
    
    private IExitableState _activeState;
    private PrefabInject _prefabInject;

    
    
    
    public GameStateMachine(SceneLoader sceneLoader, IGameObjectFactory gameObjectFactory,
      PlayerController playerController)
    {
      _states = new Dictionary<Type, IExitableState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
        [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, gameObjectFactory,playerController),
        [typeof(GameLoopState)] = new GameLoopState(gameObjectFactory, this),
      };
    }

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      TState state = ChangeState<TState>();
      state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();
      
      TState state = GetState<TState>();
      _activeState = state;
      
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => 
      _states[typeof(TState)] as TState;
  }
}