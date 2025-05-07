using Code.Gameplay.Features.Enemies.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemies
{
    public class EnemyFeature : Feature
    {
        private ISystemFactory _systemFactory;

        public EnemyFeature(ISystemFactory systemFactory)
        {
            _systemFactory = systemFactory;
            Add(_systemFactory.Create<SetMoveTargetByHeroWorldPositionSystem>());
            Add(_systemFactory.Create<EnemyDeathSystem>());
            Add(_systemFactory.Create<FinalizeEnemyDeathProcessingSystem>());
        }
    }
}