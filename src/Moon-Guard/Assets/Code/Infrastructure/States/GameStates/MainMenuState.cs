using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta;

//using Code.Meta;

namespace Code.Infrastructure.States.GameStates
{
  public class MainMenuState : IState, IUpdateable
  {
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;
    private MainMenuFeature _mainMenuFeature;

    public MainMenuState(ISystemFactory systems, GameContext gameContext)
    {
      _systems = systems;
      _gameContext = gameContext;
    }
    
    public void Enter()
    {
      _mainMenuFeature = _systems.Create<MainMenuFeature>();
      _mainMenuFeature.Initialize();
    }

    public void Update()
    {
      _mainMenuFeature.Execute();
      _mainMenuFeature.Cleanup();
    }

    public void Exit()
    {
      _mainMenuFeature.DeactivateReactiveSystems();
      _mainMenuFeature.ClearReactiveSystems();

      DestructEntities();
      
      _mainMenuFeature.Cleanup();
      _mainMenuFeature.TearDown();
      _mainMenuFeature = null;
    }
    
    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities()) 
        entity.isDestructed = true;
    }
  }
}