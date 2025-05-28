using Code.Gameplay.Features.LevelUp.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class UpdateHPMeterSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _HPMeters;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _moons;

        public UpdateHPMeterSystem(GameContext game)
        {
            _HPMeters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.HPMeter
                ));
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.View,
                    GameMatcher.FullHP,
                    GameMatcher.CurrentHP
                ));
            
            _moons = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Moon,
                    GameMatcher.View,
                    GameMatcher.FullHP,
                    GameMatcher.CurrentHP
                ));
        }

        public void Execute()
        {
            foreach (GameEntity hpMeter in _HPMeters)
            foreach (GameEntity hero in _heroes)
            {
                if(hero.View.gameObject.name == hpMeter.HPMeterTarget.gameObject.name + "(Clone)")
                    hpMeter.HPMeter.SetHP(hero.CurrentHP, hero.FullHP);
            }
            
            foreach (GameEntity hpMeter in _HPMeters)
            foreach (GameEntity moon in _moons)
            {
                if(moon.View.gameObject.name == hpMeter.HPMeterTarget.gameObject.name + "(Clone)")
                    hpMeter.HPMeter.SetHP(moon.CurrentHP, moon.FullHP);
            }
        }
    }
}