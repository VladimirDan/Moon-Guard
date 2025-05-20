using Code.Gameplay.Features.Effects.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Effects
{
    public class EffectFeature : Feature
    {
        public EffectFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RemoveEffectsWithoutTargetsSystem>());
            
            Add(systemFactory.Create<ProcessDamageEffectSystem>());
            Add(systemFactory.Create<CleanupProcessedEffects>());
        }
    }
}