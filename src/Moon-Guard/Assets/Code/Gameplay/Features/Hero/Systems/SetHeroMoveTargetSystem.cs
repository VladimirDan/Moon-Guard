using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class SetHeroMoveTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _inputs;

        public SetHeroMoveTargetSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.MovingToTarget
                    ));
            
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity hero in _heroes)
            {
                //hero.isMoving = input.hasCursorPositionInput;

                hero.ReplaceMoveTarget(input.CursorPositionInput);
            }
        }
    }
}