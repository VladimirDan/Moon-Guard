using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
    public class FinalizeProcessedArmamentsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;
        private List<GameEntity> _buffer = new (32);

        public FinalizeProcessedArmamentsSystem(GameContext gameContext, ITimeService timeService)
        {
            _armaments = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Armament,
                GameMatcher.Processed));
        }


        public void Execute()
        {
            foreach (GameEntity armament in _armaments)
            {
                armament.RemoveTargetCollectionComponents();
                armament.isDestructed = true;
            }
        }

        
    }
}