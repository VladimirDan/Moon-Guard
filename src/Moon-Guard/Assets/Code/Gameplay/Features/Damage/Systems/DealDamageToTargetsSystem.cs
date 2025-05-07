using Entitas;
using Unity.VisualScripting;

namespace Code.Gameplay.Features.Damage.Systems
{
    public class DealDamageToTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _entities;

        public DealDamageToTargetsSystem(GameContext gameContext)
        {
            _gameContext = gameContext;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.Damage,
                    GameMatcher.TargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            foreach (int targetId in entity.TargetsBuffer)
            {
                GameEntity entityWithId = _gameContext.GetEntityWithId(targetId);

                if (entityWithId.hasCurrentHP)
                {
                    entityWithId.ReplaceCurrentHP(entityWithId.CurrentHP - entity.Damage);
                }
            }
        }
    }
}