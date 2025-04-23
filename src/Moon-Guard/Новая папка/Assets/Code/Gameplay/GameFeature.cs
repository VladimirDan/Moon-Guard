using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Input.Systems;

namespace Code.Gameplay
{
    public class GameFeature : Feature
    {
        public GameFeature(GameContext gameContext, ITimeService timeService, IInputService inputService)
        {
            Add(new InputFeature(gameContext, inputService));
            Add(new MovementFeature(gameContext, timeService));
        }
    }
}