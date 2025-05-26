using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class SetHeroMoveTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<InputEntity> _inputs;

        public SetHeroMoveTargetSystem(GameContext game, InputContext input)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.MovingToTarget
                    ));
            
            _inputs = input.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            foreach (GameEntity hero in _heroes)
            {
                //hero.isMoving = input.hasCursorPositionInput;

                hero.ReplaceMoveTarget(input.CursorPositionInput);
            }
        }
    }
}