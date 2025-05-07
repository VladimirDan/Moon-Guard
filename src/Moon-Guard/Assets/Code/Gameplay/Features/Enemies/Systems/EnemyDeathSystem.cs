using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyDeathSystem : IExecuteSystem
    {
        private const float DeathTime = 2;
        private readonly IGroup<GameEntity> _enemies;

        public EnemyDeathSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath
                ));
            
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                enemy.RemoveTargetCollectionComponents();
                enemy.isMovementAvailable = false;
                enemy.ReplaceSelfDestructTimer(DeathTime);
            }
        }
    }
}