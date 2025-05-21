using Code.Gameplay.Features.Statuses.StatusVisuals;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
    public class StatusVisualFeature : Feature
    {
        public StatusVisualFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyPoisonVisualSystem>());
            Add(systemFactory.Create<ApplyFreezeVisualSystem>());
            
            Add(systemFactory.Create<UnApplyPoisonVisualSystem>());
            Add(systemFactory.Create<UnApplyFreezeVisualSystem>());
        }
    }
}