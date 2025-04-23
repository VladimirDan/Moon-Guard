using System;
using Code.Gameplay;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class EcsRunner : MonoBehaviour
    {
        private GameContext _gameContext;
        private ITimeService _timeService;

        private GameFeature _gameFeature;
        private IInputService _inputService;

        [Inject]
        public void Construct(GameContext gameContext, ITimeService timeService, IInputService inputService)
        {
            _timeService = timeService;
            _gameContext = gameContext;
            _inputService = inputService;
        }

        private void Start()
        {
            _gameFeature = new GameFeature(_gameContext, _timeService, _inputService);
            _gameFeature.Initialize();
        }

        private void Update()
        {
            _gameFeature.Execute();
            _gameFeature.Cleanup();
            
            
        }

        private void OnDestroy()
        {
            _gameFeature.TearDown();
        }
    }
}