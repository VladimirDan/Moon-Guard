using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadingMainMenuState : SimpleState
  {
    private const string MainManuSceneName = "MainMenu";
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadingMainMenuState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public override void Enter()
    {
      _sceneLoader.LoadScene(MainManuSceneName, EnterHomeScreenState);
    }

    private void EnterHomeScreenState()
    {
      _stateMachine.Enter<MainMenuState>();
    }

    public void Exit()
    {
      
    }
  }
}