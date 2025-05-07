using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : EntityComponentRegistrar
    {
        public float Speed = 2;

        public float MaxHP = 100;
        //public HeroAnimator HeroAnimator;

        public override void RegisterComponents()
        {
            Entity
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddCurrentHP(MaxHP)
                .AddFullHP(MaxHP)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovingToTarget = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }

        public override void UnregisterComponents()
        {
        }
    }
}