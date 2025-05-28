using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.GameOver.UI
{
    public class GameStopWindow : BaseWindow
    {
        private const string BattleSceneName = "Game";
        
        public Button ReturnHomeButton;
        public Button ResumeButton;
        public Button RestartButton;

        private IGameStateMachine _gameStateMachine;
        private IWindowService _windowService;
        private ITimeService _timeService;
        private IAbilityUpgradeService _abilityUpgradeService;
        
        private bool isGameOnPause;

        [Inject]
        private void Construct(IGameStateMachine stateMachine, IWindowService windowService, ITimeService timeService, IAbilityUpgradeService abilityUpgradeService)
        {
            Id = WindowId.GamePauseWindow;

            _gameStateMachine = stateMachine;
            _windowService = windowService;
            _timeService = timeService;
            _abilityUpgradeService = abilityUpgradeService;
        }

        protected override void Initialize()
        {
            isGameOnPause = _timeService.isPaused;
            ReturnHomeButton.onClick.AddListener(ReturnHome);
            ResumeButton.onClick.AddListener(Resume);
            RestartButton.onClick.AddListener(Restart);
            
            _timeService.StopTime();
        }

        private void ReturnHome()
        {
            if(!isGameOnPause)
                _timeService.StartTime();
            
            _abilityUpgradeService.Cleanup();

            _gameStateMachine.Enter<LoadingMainMenuState>();
        }
        
        private void Resume()
        {
            if(!isGameOnPause)
                _timeService.StartTime();
            _windowService.Close(Id);
        }
        
        private void Restart()
        {
            if(!isGameOnPause)
                _timeService.StartTime();
            
            _abilityUpgradeService.Cleanup();

            _gameStateMachine.Enter<LoadingBattleState, string>(BattleSceneName);
        }
    }
}