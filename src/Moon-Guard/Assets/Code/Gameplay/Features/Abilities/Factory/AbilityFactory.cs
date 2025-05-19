using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public AbilityFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateLaserShotAbility(int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.LaserShot, level);
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddAbilityId(AbilityId.LaserShot)
                .AddCooldown(abilityLevel.cooldown)
                .With(x => x.isLaserShotAbility = true)
                .PutOnCooldown();
        }
    }
}