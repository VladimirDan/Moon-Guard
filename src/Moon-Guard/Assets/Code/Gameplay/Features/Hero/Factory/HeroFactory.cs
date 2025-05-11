using Code.Common.Entity;
using Code.Common.Extensions;
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
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddViewPath("Gameplay/Hero/Hero")
                .AddWorldPosition(pos)
                .AddDirection(Vector2.zero)
                .AddSpeed(5)
                .AddCurrentHP(5)
                .AddFullHP(5)
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovingToTarget = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }
    }
}