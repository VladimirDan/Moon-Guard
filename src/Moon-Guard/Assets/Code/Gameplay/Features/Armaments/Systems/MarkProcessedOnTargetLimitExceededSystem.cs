using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class MarkProcessedOnTargetLimitExceededSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;
        private List<GameEntity> _buffer = new (32);

        public MarkProcessedOnTargetLimitExceededSystem(GameContext gameContext, ITimeService timeService)
        {
            _armaments = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Armament,
                GameMatcher.TargetLimit,
                GameMatcher.ProcessedTargetsBuffer));
        }


        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            {
                if (armament.ProcessedTargetsBuffer.Count >= armament.TargetLimit)
                {
                    armament.isProcessed = true;
                }
            }
        }

        
    }
}