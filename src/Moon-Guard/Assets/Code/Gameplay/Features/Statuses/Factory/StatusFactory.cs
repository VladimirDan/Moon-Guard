using System;
using Code.Common.Entity;
using Code.Common.Extensions;
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
    }
}