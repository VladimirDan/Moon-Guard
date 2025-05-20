using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
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

        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _laserShooters;
        private readonly IGroup<GameEntity> _enemies;
        
        private List<GameEntity> _buffer = new(32);

        public LaserShotAbilitySystem(GameContext gameContext, IStaticDataService staticDataService,
            IArmamentFactory armamentFactory)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;
            _abilities = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.LaserShotAbility,
                GameMatcher.CooldownUp));
            
            _laserShooters = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.LaserShooter,
                GameMatcher.WorldPosition
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
                _armamentFactory
                    .CreateLaserShot(1, laserShooter.WorldPosition, laserShooter.EnemyLayerMask)
                    .AddProducerId(laserShooter.Id)
                    .ReplaceDirection((FirstAvailableTarget().WorldPosition - laserShooter.WorldPosition).normalized)
                    .With(x => x.isMoving = true);
                
                ability
                    .PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.LaserShot, 1).cooldown);
            }
        }

        private GameEntity FirstAvailableTarget()
        {
            return _enemies.AsEnumerable().First();
        }
    }
}