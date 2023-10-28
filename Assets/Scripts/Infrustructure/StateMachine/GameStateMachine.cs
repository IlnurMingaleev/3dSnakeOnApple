using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.States;
using Infrustructure.Factory;
using VContainer;

namespace Infrustructure.StateMachine
{
  public class GameStateMachine : IGameStateMachine
  {
    private Dictionary<Type, IExitableState> _states;
    
    private IExitableState _activeState;
    private PrefabInject _prefabInject;

    [Inject]
    public PrefabInject PrefabInject
    {
      get => _prefabInject;
      set => _prefabInject = value;
    }
    
    
    public GameStateMachine(SceneLoader sceneLoader,  PrefabInject prefabInject)
    {
      _states = new Dictionary<Type, IExitableState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
        [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, prefabInject),
        [typeof(GameLoopState)] = new GameLoopState(this),
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