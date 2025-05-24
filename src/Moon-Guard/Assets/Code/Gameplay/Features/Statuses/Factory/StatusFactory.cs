using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enchants;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Statuses.Factory
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifierService;

        public StatusFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }


        public GameEntity CreateStatus(StatusSetup statusSetup, int producerId, int targetID)
        {
            GameEntity status = null;
            switch (statusSetup.statusTypeId)
            {
                case StatusTypeId.Unknown:
                    break;
                
                case StatusTypeId.Poisoned:
                    status = CreatePoisonStatus(statusSetup, producerId, targetID);
                    break;
                
                case StatusTypeId.Freeze:
                    status = CreateFreezeStatus(statusSetup, producerId, targetID);
                    break;
                
                case StatusTypeId.PoisonEnchant:
                    status = CreatePoisonEnchantStatus(statusSetup, producerId, targetID);
                    break;
                
                case StatusTypeId.ExplosiveEnchant:
                    status = CreateExplosiveEnchantStatus(statusSetup, producerId, targetID);
                    break;
                
                default:
                    throw new Exception($"Status {statusSetup.statusTypeId} does not exist");
            }

            status
                .With(x => x.isStatus = true, when: statusSetup.duration > 0)
                .With(x => x.AddTimeLeft(statusSetup.duration), when: statusSetup.duration > 0)
                .With(x => x.AddPeriod(statusSetup.period), when: statusSetup.period > 0)
                .With(x => x.AddTimeSinceLastTick(0), when: statusSetup.period > 0);
            
            return status;
        }

        private GameEntity CreatePoisonStatus(StatusSetup statusSetup, int producerId, int targetID)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddStatusTypeId(StatusTypeId.Poisoned)
                .AddEffectValue(statusSetup.value)
                .AddProducerId(producerId)
                .AddTargetId(targetID)
                .With(x => x.isStatus = true)
                .With(x => x.isPoison = true);
        }
        
        private GameEntity CreateFreezeStatus(StatusSetup statusSetup, int producerId, int targetID)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddStatusTypeId(StatusTypeId.Freeze)
                .AddEffectValue(statusSetup.value)
                .AddProducerId(producerId)
                .AddTargetId(targetID)
                .With(x => x.isStatus = true)
                .With(x => x.isFreeze = true);
        }
        
        private GameEntity CreatePoisonEnchantStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddStatusTypeId(StatusTypeId.PoisonEnchant)
                    .AddEnchantTypeId(EnchantTypeId.PoisonArmaments)
                    .AddEffectValue(setup.value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isPoisonEnchant = true)
                ;      
        }

        private GameEntity CreateExplosiveEnchantStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .AddStatusTypeId(StatusTypeId.ExplosiveEnchant)
                    .AddEnchantTypeId(EnchantTypeId.ExplosiveArmaments)
                    .AddEffectValue(setup.value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isExplosiveEnchant = true)
                ;
        }
    }
}