using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Factory
{
    public class LootFactory : ILootFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public LootFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateLootItem(LootTypeId lootTypeId, Vector3 at)
        {
            LootConfig lootConfig = _staticDataService.GetLootConfig(lootTypeId);

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddLootTypeId(lootTypeId)
                .AddCollectDistance(lootConfig.collectDistance)
                .AddPullSpeed(lootConfig.pullSpeed)
                .AddViewPrefab(lootConfig.viewPrefab)
                .With(x => x.isExpPullable = true, when: lootConfig.lootTypeId == LootTypeId.TechExp)
                .With(x => x.AddExperience(lootConfig.experience), when: lootConfig.experience > 0)
                .With(x => x.AddEffectSetups(lootConfig.effectSetups), when: !lootConfig.effectSetups.IsNullOrEmpty())
                .With(x => x.AddStatusSetups(lootConfig.statusSetups), when: !lootConfig.statusSetups.IsNullOrEmpty())
                .With(x => x.isPullable = true)
                ;
        }
    }
}