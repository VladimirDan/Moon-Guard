using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Movement.Systems;
using Code.Gameplay.Features.PlayerShip.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(GameContext gameContext, ITimeService timeService)
        {
            Add(new VectorDrivenMovementSystem(gameContext, timeService));
            Add(new UpdateTransformPositionSystem(gameContext));
        }
    }
}