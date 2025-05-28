using System.Collections.Generic;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.GameOver.Systems
{
    public class GameOverOnMoonDeath : ReactiveSystem<GameEntity>
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameOverOnMoonDeath(GameContext game, IGameStateMachine gameStateMachine) : base(game)
        {
            _gameStateMachine = gameStateMachine;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher
                .AllOf(
                    GameMatcher.Moon,
                    GameMatcher.Dead)
                .Added());

        protected override bool Filter(GameEntity moon) => moon.isDead;

        protected override void Execute(List<GameEntity> moons)
        {
            Debug.Log("fff");
            _gameStateMachine.Enter<GameOverState>();
        }
    }
}