using Infrustructure.StateMachine.Data;
using UnityEngine;


namespace Infrustructure.StateMachine
{
  public class GameLoopState : IPayloadedState<IDataBetweenStates>
  {
    
    private readonly IGameStateMachine _stateMachine;
    private IDataBetweenStates _dataBetweenStates;
    private IGameRunner _gameRunner;
    public GameLoopState(IGameStateMachine gameStateMachine)
    {
      _stateMachine = gameStateMachine;
    }

    

    

    public void Enter(IDataBetweenStates payload)
    {
      _dataBetweenStates = payload;
      _gameRunner = Object.FindObjectOfType(typeof(GameRunner)) as GameRunner;
      if (_gameRunner != null) _gameRunner.Init(_dataBetweenStates);
    }

    public void Exit()
    {
      
    }

    
    
    

    

    
  }

  
}