using Infrustructure.Factory;
using Infrustructure.StateMachine.Data;
using Logic.Camera;
using Logic.Consumables.Views;
using Logic.GravityPhysics;
using Logic.Snake.Controllers;
using Logic.Snake.Views;
using Logic.Tools.Pooling;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrustructure.StateMachine
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private IGameObjectFactory _gameObjectFactory;

    
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
      ConsumablesParentView consumablesParentView = Object.FindObjectOfType<ConsumablesParentView>(); 
      Planet planet = Object.FindObjectOfType<Planet>();
      SnakeBodyParent snakeBodyParent = Object.FindObjectOfType<SnakeBodyParent>();
      GameObject snakeHead = _gameObjectFactory.Create(
        AssetPath._snakeHead,Object.FindObjectOfType<PlayerHeadParent>().transform, true);
      _playerController.Initialize(snakeHead.GetComponent<PlayerView>());
      snakeHead.GetComponent<PlayerView>().InitPlayer(planet,snakeBodyParent);
      
      
      
      
      if (snakeHead != null)
      {
        CameraFollow(snakeHead);  
      }

      DataBetweenStates dataBetweenStates = new DataBetweenStates(_playerController,consumablesParentView, snakeBodyParent, planet);
      _stateMachine.Enter<GameLoopState, IDataBetweenStates>(dataBetweenStates);
    }

    public void CameraFollow(GameObject player) =>
      Camera.main.GetComponent<CameraFollow>().Follow(player);
    
  }
  
}