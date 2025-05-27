using System;

namespace Code.Meta.UI.HUD.ScoreHolder.Service
{
    public interface IStorageUIService
    {
        event Action CurrentScoreChange;
        event Action HighScoreChange;
        float CurrentScore { get; }
        float HighScore { get; }
        void UpdateCurrentScore(float score);
        void UpdateHighScore(float score);
        void Cleanup();
    }
}