using Code.Gameplay.Features.LevelUp.Systems;
using Code.Gameplay.Features.Loot.Systems;
using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Loot
{
    public class LootFeature : Feature
    {
        public LootFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CastForPullablesSystem>());
            Add(systemFactory.Create<CastForExpPullablesSystem>());
            Add(systemFactory.Create<PullTowardsHeroSystem>());
            Add(systemFactory.Create<CollectWhenNearSystem>());
            
            Add(systemFactory.Create<CollectExpirienceSystem>());
            Add(systemFactory.Create<CollectEffectItemSystem>());
            Add(systemFactory.Create<CollectStatusItemSystem>());
            
            Add(systemFactory.Create<UpdateExperienceMeterSystem>());
            
            Add(systemFactory.Create<CleanupCollectedSystem>());
        }
    }
}