using CodeBase.Infrastructure.States;
using Logic.Snake;
using VContainer.Unity;

namespace Infrustructure.StateMachine
{
  public class GameLoopState : IPayloadedState<PlayerController>,IFixedTickable,ITickable
  {
    
    private readonly IGameStateMachine _stateMachine;
    private PlayerController _playerController;
    private bool _initialized = false;
    private bool _startCalled = false;
    public GameLoopState(IGameStateMachine gameStateMachine)
    {
      _stateMachine = gameStateMachine;
    }

    private void SetPlayerController(PlayerController playerController)
    {
      _playerController = playerController;
    }

    public void Enter(PlayerController payload)
    {
      SetPlayerController(payload);
      _playerController.Initialize();
      _startCalled = true;
    }

    public void Exit()
    {
      
    }

    
    
    public void FixedTick()
    { 
      if (_startCalled)
      {
          _playerController.Start();
          //_startCalled = true;
          _initialized = true;
      }
      if(_initialized)
      {
        _playerController.FixedUpdate();
      }

      
      
    }

    public void Tick()
    {
      if ( _initialized)
      {
        _playerController.Update();
      }
    }

    
  }
}