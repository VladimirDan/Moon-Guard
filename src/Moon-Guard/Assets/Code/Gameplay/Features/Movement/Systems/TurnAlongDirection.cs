using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class TurnAlongDirection: IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public TurnAlongDirection(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TurnedAlongDirection,
                    GameMatcher.Direction,
                    GameMatcher.Transform
                    ));
        }
    
        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                Vector2 direction = mover.Direction; 
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                mover.Transform.transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}