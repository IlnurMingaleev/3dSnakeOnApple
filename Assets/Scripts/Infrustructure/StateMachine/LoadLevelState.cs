using Infrustructure;
using Infrustructure.Factory;
using Infrustructure.StateMachine;
using Logic.Camera;
using Logic.Snake;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private const string InitialPointTag = "InitialPoint";

    private readonly IGameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private PrefabInject _prefabInject;
    
    public LoadLevelState(IGameStateMachine gameStateMachine,
      SceneLoader sceneLoader, PrefabInject prefabInject)
    {
      _stateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _prefabInject = prefabInject;

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
      GameObject snakeHead =Object.Instantiate(
        Resources.Load(AssetPath._snakeHead, typeof(GameObject))) as GameObject;
      //GameObject hud = Object.Instantiate(
        //Resources.Load(AssetPath.HudPath, typeof(GameObject))) as GameObject;
      //GameObject camera = Object.Instantiate(
        //Resources.Load(AssetPath.CameraPath, typeof(GameObject))) as GameObject;

      //GameObject hero = null;
      _prefabInject.InjectGameObject(snakeHead);
      //_prefabInject.InjectGameObject(hud);
      //_prefabInject.InjectGameObject(camera);
      
      
      
      if (snakeHead != null)
      {
        CameraFollow(snakeHead);  
      }
      _stateMachine.Enter<GameLoopState, PlayerController>(_prefabInject._objectResolver.Resolve<PlayerController>());
    }

    public void CameraFollow(GameObject player) =>
      Camera.main.GetComponent<CameraFollow>().Follow(player);
  }
}