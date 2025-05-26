using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Score.Systems
{
    public class InitializeCurrentScoreSystem : IInitializeSystem
    {
        private readonly IGroup<GameEntity> _scores;
        private List<GameEntity> _buffer = new(8);

        public InitializeCurrentScoreSystem(GameContext game)
        {
            _scores = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Score,
                    GameMatcher.HighScore
                ).NoneOf(GameMatcher.CurrentScore));
        }

        public void Initialize()
        {
            foreach (GameEntity score in _scores.GetEntities(_buffer))
            {
                score.AddCurrentScore(0);
            }
        }
    }
}