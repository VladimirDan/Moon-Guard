using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.LifeTime.Systems
{
    public class SetDeadStatusToReachedMeteorSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _meteors;
        private List<GameEntity> _buffer = new(256);

        public SetDeadStatusToReachedMeteorSystem(GameContext game)
        {
            _meteors = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Meteor,
                    GameMatcher.Reached
                ).NoneOf(GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _meteors.GetEntities(_buffer))
            {
                entity.isDead = true;
                entity.isProcessingDeath = true;
            }
        }
    }
}