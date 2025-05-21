using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class CleanupUnAppliedStatusLinkedChanges: ICleanupSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);
        
        public CleanupUnAppliedStatusLinkedChanges(GameContext gameContext)
        {
            _gameContext = gameContext;
            _statuses = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.Status,
                GameMatcher.Unapplied));
        }
        public void Cleanup()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            foreach (GameEntity entity in _gameContext.GetEntitiesWithApplierStatusLink(status.Id))
            {
                status.isDestructed = true;
            }
        }
    }
}