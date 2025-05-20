using System.Linq;
using Code.Common.Entity.EntityIndices;
using Code.Common.Extensions;
using Code.Gameplay.Features.Statuses.Factory;

namespace Code.Gameplay.Features.Statuses.Applier
{
    public class StatusApplier : IStatusApplier
    {
        private readonly IStatusFactory _statusFactory;
        private readonly GameContext _gameContext;

        public StatusApplier(IStatusFactory statusFactory, GameContext gameContext)
        {
            _statusFactory = statusFactory;
            _gameContext = gameContext;
        }

        public GameEntity ApplyStatus(StatusSetup statusSetup, int producerId, int targetId)
        {
            GameEntity status = _gameContext.TargetStatusesOfType(statusSetup.statusTypeId, targetId).FirstOrDefault();
            if (status != null)
                return status.ReplaceTimeLeft(statusSetup.duration);
            else
                return _statusFactory.CreateStatus(statusSetup, producerId, targetId)
                    .With(x=> x.isApplied = true);
        }
    }
}