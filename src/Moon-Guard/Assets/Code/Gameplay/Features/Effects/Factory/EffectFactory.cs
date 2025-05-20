using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effects.Factory
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IIdentifierService _identifierService;

        public EffectFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEffect(EffectSetup effectSetup, int producerId, int targetId)
        {
            switch (effectSetup.effectTypeId)
            {
                case EffectTypeId.Unknown:
                    break;
                case EffectTypeId.Damage:
                    return CreateDamageEffect(producerId, targetId, effectSetup.value);
            }
            
            throw new Exception($"Effect {effectSetup.effectTypeId} does not exist");
        }

        private GameEntity CreateDamageEffect(int producerId, int targetId, float damage)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isEffect = true)
                .With(x => x.isDamageEffect = true)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .AddEffectValue(damage);
        }
    }
}