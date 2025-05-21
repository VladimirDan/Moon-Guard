using System;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessHealEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public ProcessHealEffectSystem(GameContext gameContext)
        {
            _effects = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.HealEffect,
                GameMatcher.EffectValue,
                GameMatcher.TargetId));
        }


        public void Execute()
        {
            foreach (GameEntity effect in _effects)
            {
                GameEntity target = effect.Target();

                effect.isProcessed = true;
                
                if (target.isDead)
                {
                    continue;
                }

                if (target.hasFullHP && target.hasCurrentHP)
                {
                    float newHPValue = Math.Min(target.CurrentHP + effect.EffectValue, target.FullHP);
                    target.ReplaceCurrentHP(newHPValue);
                }
            }
        }
    }
}