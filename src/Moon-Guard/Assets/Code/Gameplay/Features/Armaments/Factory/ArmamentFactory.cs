using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public class ArmamentFactory : IArmamentFactory
    {
        private const int TargetBufferSize = 16;
        private readonly IIdentifierService _identifierService;
        private IStaticDataService _staticDataService;

        public ArmamentFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateLaserShot(int level, Vector3 pos, int enemyLayerMask)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.LaserShot, level);
            ProjectileSetup setup = abilityLevel.projectileSetup;

            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isArmament = true)
                .AddViewPrefab(abilityLevel.viewPrefab)
                .AddWorldPosition(pos)
                .AddSpeed(setup.speed)
                .AddEffectSetups(abilityLevel.effectSetups)
                .AddStatusSetups(abilityLevel.StatusSetups)
                .AddTargetLimit(setup.pierce)
                .AddTargetsSelectionRadius(setup.contactRadius)
                .AddTargetsBuffer(new List<int>(TargetBufferSize))
                .AddProcessedTargetsBuffer(new List<int>(TargetBufferSize))
                .AddLayerMask(enemyLayerMask)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContinuously = true)
                .AddSelfDestructTimer(setup.lifeTime);
                ;
        }
    }
}