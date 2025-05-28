using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class LaserShotAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _laserShooters;
        private readonly IGroup<GameEntity> _enemies;
        
        private List<GameEntity> _buffer = new(32);

        public LaserShotAbilitySystem(GameContext gameContext, IStaticDataService staticDataService,
            IArmamentFactory armamentFactory, IAbilityUpgradeService abilityUpgradeService)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;
            _abilityUpgradeService = abilityUpgradeService;
            _abilities = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.LaserShotAbility,
                GameMatcher.CooldownUp));
            
            _laserShooters = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.LaserShooter,
                GameMatcher.WorldPosition,
                GameMatcher.Direction
                ));
            
            _enemies  = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.WorldPosition
            )); 
        }


        public void Execute()
        {
            foreach (GameEntity laserShooter in _laserShooters)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                int abilityLevel = _abilityUpgradeService.GetAbilityLevel(AbilityId.LaserShot);
                _armamentFactory
                    .CreateLaserShot(abilityLevel, laserShooter.WorldPosition, laserShooter.EnemyLayerMask)
                    .AddProducerId(laserShooter.Id)
                    .ReplaceDirection(laserShooter.Direction)
                    .With(x => x.isMoving = true);
                
                ability
                    .PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.LaserShot, abilityLevel).cooldown);
            }
        }

        private GameEntity FirstAvailableTarget()
        {
            return _enemies.AsEnumerable().First();
        }
    }
}