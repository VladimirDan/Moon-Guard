using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
  public class EnemyRegistrar : EntityComponentRegistrar
  {
    public float Speed = 1;
    public float MaxHP = 10;
    public float Damage = 1;
    
    private GameEntity _entity;
    
    public override void RegisterComponents()
    {
      Entity
        .AddEnemyTypeId(EnemyTypeId.Goblin)
        .AddWorldPosition(transform.position)
        .AddSpeed(Speed)
        .AddCurrentHP(MaxHP)
        .AddFullHP(MaxHP)
        .AddDamage(Damage)
        .AddTargetsBuffer(new List<int>(1))
        .AddTargetsSelectionRadius(0.3f)
        .AddCollectTargetsInterval(0.5f)
        .AddCollectTargetsTimer(0)
        .AddLayerMask(CollisionLayer.Hero.AsMask())
        .With(x => x.isEnemy = true)
        .With(x => x.isTurnedAlongDirection = true)
        .With(x => x.isMovingToTarget = true)
        .With(x => x.isMovingToHero = true)
        .With(x => x.isMovementAvailable = true)
        ;
    }

    public override void UnregisterComponents()
    {
      
    }
  }
}