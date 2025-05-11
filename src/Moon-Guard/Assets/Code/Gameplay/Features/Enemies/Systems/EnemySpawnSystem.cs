﻿using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Enemies.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemySpawnSystem : IExecuteSystem
    {
        public const float SpawnDistanceGap = 1f;
        
        private readonly ITimeService _timeService;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _timers;
        private readonly IGroup<GameEntity> _heroes;

        public EnemySpawnSystem(GameContext gameContext, ITimeService timeService,
            IEnemyFactory enemyFactory, ICameraProvider cameraProvider)
        {
            _timeService = timeService;
            _enemyFactory = enemyFactory;
            _cameraProvider = cameraProvider;
            _timers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SpawnTimer
                ));

            _heroes = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity timer in _timers)
            {
                timer.ReplaceSpawnTimer(timer.SpawnTimer - _timeService.DeltaTime);
                if (timer.SpawnTimer <= 0)
                {
                    timer.ReplaceSpawnTimer(GamePlayConstants.EnemySpawnTimer);
                    _enemyFactory.CreateEnemy(EnemyTypeId.Predator, pos: RandomSpawnPosition(hero.WorldPosition));
                }
            }
            
        }

        private Vector2 RandomSpawnPosition(Vector2 heroWorldPosition)
        {
            bool startWithHorizontal = Random.Range(0, 2) == 0;

            return startWithHorizontal 
                ? HorizontalSpawnPosition(heroWorldPosition) 
                : VerticalSpawnPosition(heroWorldPosition);
        }

        private Vector2 HorizontalSpawnPosition(Vector2 heroWorldPosition)
        {
            Vector2[] horizontalDirections = { Vector2.left, Vector2.right };
            Vector2 primaryDirection = horizontalDirections.PickRandom();
      
            float horizontalOffsetDistance = _cameraProvider.WorldScreenWidth / 2 + SpawnDistanceGap;
            float verticalRandomOffset = Random.Range(-_cameraProvider.WorldScreenHeight / 2, _cameraProvider.WorldScreenHeight / 2);

            return heroWorldPosition + primaryDirection * horizontalOffsetDistance + Vector2.up * verticalRandomOffset;
        }

        private Vector2 VerticalSpawnPosition(Vector2 heroWorldPosition)
        {
            Vector2[] verticalDirections = { Vector2.up, Vector2.down };
            Vector2 primaryDirection = verticalDirections.PickRandom();
      
            float verticalOffsetDistance = _cameraProvider.WorldScreenHeight / 2 + SpawnDistanceGap;
            float horizontalRandomOffset = Random.Range(-_cameraProvider.WorldScreenWidth / 2, _cameraProvider.WorldScreenWidth / 2);

            return heroWorldPosition + primaryDirection * verticalOffsetDistance + Vector2.right * horizontalRandomOffset;
        }
    }
}