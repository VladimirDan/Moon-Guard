using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class SetMoveTargetByHeroWorldPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public SetMoveTargetByHeroWorldPositionSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.WorldPosition,
                    GameMatcher.MovingToHero));
            
            _heroes = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition
                    ));
        }

        public void Execute()
        {
            
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity enemy in _enemies)
            {
                Vector2 heroPosition = hero.WorldPosition;
                enemy.ReplaceMoveTarget(heroPosition);
                //enemy.isMoving = true;
            }
        }
    }
}