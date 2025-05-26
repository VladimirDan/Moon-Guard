using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class UpdateCurrentScore : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _scores;
        private List<GameEntity> _buffer = new(8);
        private readonly IGroup<GameEntity> _loots;

        public UpdateCurrentScore(GameContext game)
        {
            _scores = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Score,
                    GameMatcher.HighScore,
                    GameMatcher.CurrentScore
                ));
            
            _loots = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Collected,
                    GameMatcher.Experience
                ));
        }

        public void Execute()
        {
            foreach (GameEntity score in _scores.GetEntities(_buffer))
            foreach (GameEntity loot in _loots)
            {
                score.ReplaceCurrentScore(score.CurrentScore + loot.Experience);
            }
        }
    }
}