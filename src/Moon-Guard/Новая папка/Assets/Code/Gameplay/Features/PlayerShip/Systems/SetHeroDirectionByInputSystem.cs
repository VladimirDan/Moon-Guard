using Entitas;

namespace Code.Gameplay.Features.PlayerShip.Systems
{
    public class SetHeroDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heros;
        private readonly IGroup<GameEntity> _inputs;

        public SetHeroDirectionByInputSystem(GameContext gameContext)
        {
            _heros = gameContext.GetGroup(GameMatcher.Hero);
            _inputs = gameContext.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity hero in _heros)
            {
                hero.isMoving = input.hasAxisInput;

                if (input.hasAxisInput)
                {
                    hero.ReplaceDirection(input.AxisInput.normalized);
                }
            }
        }
    }
}