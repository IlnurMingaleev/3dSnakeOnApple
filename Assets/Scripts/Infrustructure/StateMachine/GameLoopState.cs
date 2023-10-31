using Infrustructure.Factory;
using Infrustructure.StateMachine.Data;
using Logic.Consumables.Views;
using Logic.Snake.Views;
using Logic.Tools.Pooling;
using UnityEngine;


namespace Infrustructure.StateMachine
{
  public class GameLoopState : IPayloadedState<IDataBetweenStates>
  {
    
    private readonly IGameStateMachine _stateMachine;
    private IDataBetweenStates _dataBetweenStates;
    private IGameObjectPool<IPlayerBodyPartView> _bodyPartsPool;
    private IGameObjectFactory _gameObjectFactory;

    private IConsuamablesProvider _consumablesProvider;
    private IGameRunner _gameRunner;
    public GameLoopState(IGameObjectFactory gameObjectFactory,IGameStateMachine gameStateMachine)
    {
      _gameObjectFactory = gameObjectFactory;
      _stateMachine = gameStateMachine;
    }

    

    

    public void Enter(IDataBetweenStates payload)
    {
      _dataBetweenStates = payload;

      _gameRunner = Object.FindObjectOfType<GameRunner>();
      if (_gameRunner != null) _gameRunner.Init(_dataBetweenStates, 
        _gameObjectFactory);
    }

    public void Exit()
    {
      
    }

    
    
    

    

    
  }

  
}