using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class HeroDeathSystem : IExecuteSystem
    {
        private const float DeathTime = 2;
        private readonly IGroup<GameEntity> _heroes;

        public HeroDeathSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Dead,
                    GameMatcher.ProcessingDeath
                ));
            
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.RemoveTargetCollectionComponents();
                hero.isMovementAvailable = false;
                hero.ReplaceSelfDestructTimer(DeathTime);
            }
        }
    }
}