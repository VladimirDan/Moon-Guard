using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta;
using Code.Meta.UI.HUD.ScoreHolder.Service;

//using Code.Meta;

namespace Code.Infrastructure.States.GameStates
{
    public class MainMenuState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systems;
        private readonly GameContext _gameContext;
        private readonly IStorageUIService _storageUIService;
        private MainMenuFeature _mainMenuFeature;

        public MainMenuState(ISystemFactory systems, GameContext gameContext, IStorageUIService storageUIService)
        {
            _systems = systems;
            _gameContext = gameContext;
            _storageUIService = storageUIService;
        }

        public override void Enter()
        {
            _mainMenuFeature = _systems.Create<MainMenuFeature>();
            _mainMenuFeature.Initialize();
        }

        protected override void OnUpdate()
        {
            _mainMenuFeature.Execute();
            _mainMenuFeature.Cleanup();
        }

        protected override void ExitOnEndOfFrame()
        {
            _storageUIService.Cleanup();
            
            _mainMenuFeature.DeactivateReactiveSystems();
            _mainMenuFeature.ClearReactiveSystems();

            _mainMenuFeature.Cleanup();
            _mainMenuFeature.TearDown();
            _mainMenuFeature = null;
        }
    }
}