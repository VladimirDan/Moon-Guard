using System.Collections.Generic;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Levels;
using Code.Progress.SaveLoad;
using Entitas;

namespace Code.Gameplay.Features.Score.Systems
{
    public class UpdateHighScoreSystem : IExecuteSystem
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGroup<GameEntity> _scores;
        private List<GameEntity> _buffer = new(8);

        public UpdateHighScoreSystem(GameContext game, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _scores = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Score,
                    GameMatcher.CurrentScore,
                    GameMatcher.HighScore
                ));
        }

        public void Execute()
        {
            foreach (GameEntity score in _scores.GetEntities(_buffer))
            {
                if (score.CurrentScore > score.HighScore)
                {
                    score.ReplaceHighScore(score.CurrentScore);
                    _saveLoadService.SaveProgress();
                }
            }
        }
    }
}