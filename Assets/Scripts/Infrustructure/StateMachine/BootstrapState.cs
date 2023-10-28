using Helpers;
using Infrustructure;


namespace CodeBase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private const string Initial = "Initial";
    private readonly IGameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(IGameStateMachine stateMachine, SceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      
    }

    public void Enter()
    {
      EnterLoadLevel();
    }

    public void Exit()
    {
    }
    

    private void EnterLoadLevel() =>
      _stateMachine.Enter<LoadLevelState, string>(Constants._gameSceneName);

   
  }
}