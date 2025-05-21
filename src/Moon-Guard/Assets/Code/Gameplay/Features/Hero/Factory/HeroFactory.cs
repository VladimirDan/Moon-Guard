using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;

        public HeroFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateHero(Vector3 pos)
        {
            Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.Speed] = 2)
                .With(x => x[Stats.MaxHp] = 100);
            
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddViewPath("Gameplay/Hero/Hero")
                .AddWorldPosition(pos)
                .AddBaseStats(baseStats)
                .AddStatModifiers(InitStats.EmptyStatDictionary())
                .AddDirection(Vector2.zero)
                .AddSpeed(baseStats[Stats.Speed])
                .AddCurrentHP(baseStats[Stats.MaxHp])
                .AddFullHP(baseStats[Stats.MaxHp])
                .AddEnemyLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isLaserShooter = true)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovingToTarget = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}