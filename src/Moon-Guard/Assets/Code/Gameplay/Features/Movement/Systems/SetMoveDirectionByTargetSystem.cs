using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class SetMoveDirectionByTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public SetMoveDirectionByTargetSystem(GameContext game)
        {
            _movers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.MoveTarget,
                    GameMatcher.MovementAvailable
                ));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                mover.isMoving = true;
                Vector2 currentPosition = mover.WorldPosition;
                Vector2 targetPosition = mover.MoveTarget;

                Vector2 newDirection = (targetPosition - currentPosition).normalized;
                mover.ReplaceDirection(newDirection);
            }
        }
    }
}

