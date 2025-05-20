using Code.Gameplay.Features.EffectApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.EffectApplication
{
    public class EffectApllicationFeature : Feature
    {
        public EffectApllicationFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyEffectsOnTargetsSystem>());
            Add(systemFactory.Create<ApplyStatusesOnTargetsSystem>());
        }
    }
}