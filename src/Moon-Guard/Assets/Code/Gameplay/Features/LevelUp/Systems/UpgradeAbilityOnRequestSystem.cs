using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.LevelUp.Services;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
    public class UpgradeAbilityOnRequestSystem : IExecuteSystem
    {
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IGroup<GameEntity> _upgradeRequests;
        private readonly IGroup<GameEntity> _levelUps;

        public UpgradeAbilityOnRequestSystem(GameContext game, IAbilityUpgradeService  abilityUpgradeService)
        {
            _abilityUpgradeService = abilityUpgradeService;
            _upgradeRequests = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.UpgradeRequest,
                    GameMatcher.AbilityId
                ));
            
            _levelUps = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LevelUp
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity upgradeRequest in _upgradeRequests)
            foreach (GameEntity levelUp in _levelUps)
            {
                _abilityUpgradeService.UpgradeAbility(upgradeRequest.AbilityId);

                levelUp.isProcessed = true;
                upgradeRequest.isDestructed = true;
            }
        }
    }
}