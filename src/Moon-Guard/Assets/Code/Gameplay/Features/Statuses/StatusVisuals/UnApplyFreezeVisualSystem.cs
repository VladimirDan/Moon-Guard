using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Statuses.StatusVisuals
{
    public class UnApplyFreezeVisualSystem : ReactiveSystem<GameEntity>
    {
        public UnApplyFreezeVisualSystem(GameContext gameContext) : base(gameContext)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(
                    GameMatcher.Freeze,
                    GameMatcher.Status,
                    GameMatcher.Unapplied)
                .Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isStatus && entity.isFreeze && entity.hasTargetId;
        }

        protected override void Execute(List<GameEntity> statuses)
        {
            foreach (GameEntity status in statuses)
            {
                GameEntity target = status.Target();
                if (target is { hasStatusVisuals: true })
                {
                    target.StatusVisuals.UnapplyFreeze();
                }
            }
        }
    }
}