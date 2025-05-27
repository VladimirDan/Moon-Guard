using Code.Meta.UI.HUD.ScoreHolder.Service;
using Entitas;

namespace Code.Meta.UI.HUD.ScoreHolder.Systems
{
    public class RefreshHighScoreSystem : IExecuteSystem
    {
        private readonly IStorageUIService _storageUIService;
        private readonly IGroup<GameEntity> _storages;

        public RefreshHighScoreSystem(GameContext game, IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
            _storages = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Score,
                    GameMatcher.HighScore));
        }

        public void Execute()
        {
            foreach (GameEntity storage in _storages)
            {
                _storageUIService.UpdateHighScore(storage.HighScore);
            }
        }
    }
}