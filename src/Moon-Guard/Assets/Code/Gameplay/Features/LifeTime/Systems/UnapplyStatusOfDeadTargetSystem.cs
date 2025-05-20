using Entitas;

namespace Code.Gameplay.Features.LifeTime.Systems
{
    public class UnapplyStatusOfDeadTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _dead;

        public UnapplyStatusOfDeadTargetSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.TargetId
                ));
            
            _dead = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Dead
                ));
            
        }

        public void Execute()
        {
            foreach (GameEntity entity in _dead)
            foreach (GameEntity status in _statuses)
            {
                if (status.TargetId == entity.Id)
                    status.isUnapplied = true;
            }
        }
    }
}