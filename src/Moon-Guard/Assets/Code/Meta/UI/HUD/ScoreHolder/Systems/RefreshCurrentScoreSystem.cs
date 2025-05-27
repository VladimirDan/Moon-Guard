using Code.Meta.UI.HUD.ScoreHolder.Service;
using Entitas;
using UnityEngine;

namespace Code.Meta.UI.HUD.ScoreHolder.Systems
{
    public class RefreshCurrentScoreSystem : IExecuteSystem
    {
        private readonly IStorageUIService _storageUIService;
        private readonly IGroup<GameEntity> _storages;

        public RefreshCurrentScoreSystem(GameContext game, IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
            _storages = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Score,
                    GameMatcher.CurrentScore));
        }

        public void Execute()
        {
            foreach (GameEntity storage in _storages)
            {
                _storageUIService.UpdateCurrentScore(storage.CurrentScore);
            }
        }
    }
}