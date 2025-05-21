using System;
using System.Collections.Generic;
using Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Effects;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;

        public EnemyFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        public GameEntity CreateEnemy(EnemyTypeId enemyTypeId, Vector3 pos)
        {
            switch (enemyTypeId)
            {
                case EnemyTypeId.Predator:
                    return CreatePredator(pos);
            }
            
            throw new ArgumentOutOfRangeException(nameof(enemyTypeId), enemyTypeId, null);
        }

        private GameEntity CreatePredator(Vector2 pos)
        {
            Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.Speed] = 1)
                .With(x => x[Stats.MaxHp] = 5)
                .With(x => x[Stats.Damage] = 1);
            
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddViewPath("Gameplay/Enemies/Predators/Predator/Predator")
                .AddEnemyTypeId(EnemyTypeId.Predator)
                .AddWorldPosition(pos)
                .AddBaseStats(baseStats)
                .AddStatModifiers(InitStats.EmptyStatDictionary())
                .AddSpeed(baseStats[Stats.Speed])
                .AddCurrentHP(baseStats[Stats.MaxHp])
                .AddFullHP(baseStats[Stats.MaxHp])
                .AddEffectSetups(new List<EffectSetup>(){new(){effectTypeId = EffectTypeId.Damage, value = baseStats[Stats.Damage]}})
                .AddTargetsBuffer(new List<int>(1))
                .AddTargetsSelectionRadius(0.3f)
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovingToTarget = true)
                .With(x => x.isMovingToHero = true)
                .With(x => x.isMovementAvailable = true);
        }
    }
}