using Infrustructure.Factory;
using Infrustructure.StateMachine.Data;
using Logic.Camera;
using Logic.Consumables.Views;
using Logic.GravityPhysics;
using Logic.Snake.Controllers;
using Logic.Snake.Views;
using Logic.Tools.Pooling;
using UnityEngine;

namespace Infrustructure.StateMachine
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private IGameObjectFactory _gameObjectFactory;

    private IGameObjectPool<IPlayerBodyPartView> _bodyPartsPool;

    private IGameObjectPool<IConsumableView> _consumablesPool;
    private PlayerController _playerController;

    //private IDataBetweenStates _dataBetweenStates;
    public LoadLevelState(IGameStateMachine gameStateMachine,
      SceneLoader sceneLoader,
      IGameObjectFactory gameObjectFactory, 
      PlayerController playerController)
    {
      _stateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _gameObjectFactory = gameObjectFactory;
      _playerController = playerController;
      //_dataBetweenStates = dataBetweenStates;

    }

    public void Enter(string sceneName)
    { 
      _sceneLoader.Load(sceneName, OnLoaded);
    }
    public void Exit() 
    {
    }
    

    private void OnLoaded()
    {
      //Scene dependencies
      ConsumablesParentView consumablesParentView = Object.FindObjectOfType(typeof(ConsumablesParentView)) as ConsumablesParentView;
      Planet planet = Object.FindObjectOfType(typeof(Planet)) as Planet;
      SnakeBodyParent snakeBodyParent = Object.FindObjectOfType(typeof(SnakeBodyParent)) as SnakeBodyParent;
      GameObject snakeHead = _gameObjectFactory.Create(
        AssetPath._snakeHead,
        (Transform) Object.FindObjectOfType(typeof(PlayerHeadParent)), true);
      snakeHead.GetComponent<PlayerView>().InitPlayer(planet,snakeBodyParent);
      _consumablesPool = new ConsuamblesPool(_gameObjectFactory,consumablesParentView, planet);
      _playerController.Initialize(snakeHead.GetComponent<PlayerView>());
      _bodyPartsPool = new PlayerBodyPartsPool(_gameObjectFactory,_playerController, snakeBodyParent);
      
      IConsumableView currentConsumable = _consumablesPool.Get(()=>
      {
        _consumablesPool.ReturnAll();
        IPlayerBodyPartView playerBodyPartView = _bodyPartsPool.Get();
        _playerController.AddBodyPart(_bodyPartsPool.GetPoolElementsAsList(),playerBodyPartView);
      });
      
      if (snakeHead != null)
      {
        CameraFollow(snakeHead);  
      }

      DataBetweenStates dataBetweenStates = new DataBetweenStates( ref _bodyPartsPool, ref _consumablesPool, ref _playerController,  ref currentConsumable);
      _stateMachine.Enter<GameLoopState, IDataBetweenStates>(dataBetweenStates);
    }

    public void CameraFollow(GameObject player) =>
      Camera.main.GetComponent<CameraFollow>().Follow(player);
    
  }
  
}