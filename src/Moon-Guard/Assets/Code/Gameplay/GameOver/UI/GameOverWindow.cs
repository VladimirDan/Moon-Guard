using Code.Gameplay.Common.Time;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.GameOver.UI
{
    public class GameOverWindow : BaseWindow
    {
        public Button ReturnHomeButton;
        public Button RestartButton;
        private const string BattleSceneName = "Game";

        private IGameStateMachine _gameStateMachine;
        private IWindowService _windowService;
        private ITimeService _timeService;
        private bool isGameOnPause;

        [Inject]
        private void Construct(IGameStateMachine stateMachine, IWindowService windowService, ITimeService timeService)
        {
            _timeService = timeService;
            Id = WindowId.GameOverWindow;

            _gameStateMachine = stateMachine;
            _windowService = windowService;
        }

        protected override void Initialize()
        {
            isGameOnPause = _timeService.isPaused;
            ReturnHomeButton.onClick.AddListener(ReturnHome);
            RestartButton.onClick.AddListener(Restart);
            _timeService.StopTime();
        }

        private void ReturnHome()
        {
            if(!isGameOnPause)
                _timeService.StartTime();
            
            //_windowService.Close(Id);

            _gameStateMachine.Enter<LoadingMainMenuState>();
        }
        
        private void Restart()
        {
            if(!isGameOnPause)
                _timeService.StartTime();
            
            _gameStateMachine.Enter<LoadingBattleState, string>(BattleSceneName);
        }
    }
}