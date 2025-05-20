using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class CleanupUnAppliedStatuses: ICleanupSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);
        
        public CleanupUnAppliedStatuses(GameContext gameContext)
        {
            _statuses = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Status,
                GameMatcher.Unapplied));
        }
        public void Cleanup()
        {
            foreach (GameEntity effect in _statuses.GetEntities(_buffer))
            {
                effect.isDestructed = true;
            }
        }
    }
}