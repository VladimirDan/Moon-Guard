using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Time;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.Provider;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;

namespace Code.Infrastructure.States.GameStates
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(
            IGameStateMachine stateMachine,
            ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            InitializeProgress();

            _stateMachine.Enter<LoadingMainMenuState>();
        }

        private void InitializeProgress()
        {
            if (_saveLoadService.HasSavedProgress)
                _saveLoadService.LoadProgress();
            else
                CreateNewProgress();   
        }

        private void CreateNewProgress()
        {
            _saveLoadService.CreateProgress();

            CreateEntity.Empty()
                .AddHighScore(0)
                .AddCurrentScore(0)
                .With(x => x.isScore = true);
        }

        public void Exit()
        {
        }
    }
}