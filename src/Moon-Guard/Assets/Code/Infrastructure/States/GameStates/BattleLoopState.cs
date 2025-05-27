using System.Collections;
using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta.UI.HUD.ScoreHolder.Service;

namespace Code.Infrastructure.States.GameStates
{
    public class BattleLoopState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systems;
        private BattleFeature _battleFeature;
        private readonly GameContext _gameContext;
        private readonly IStorageUIService _storageUIService;

        public BattleLoopState(ISystemFactory systems, GameContext gameContext, IStorageUIService storageUIService)
        {
            _systems = systems;
            _gameContext = gameContext;
            _storageUIService = storageUIService;
        }

        public override void Enter()
        {
            _battleFeature = _systems.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        protected override void OnUpdate()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        protected override void ExitOnEndOfFrame()
        {
            _storageUIService.Cleanup();
            
            _battleFeature.DeactivateReactiveSystems();
            _battleFeature.ClearReactiveSystems();

            DestructEntities();

            _battleFeature.Cleanup();
            _battleFeature.TearDown();
            _battleFeature = null;
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities())
                entity.isDestructed = true;
        }
    }
}