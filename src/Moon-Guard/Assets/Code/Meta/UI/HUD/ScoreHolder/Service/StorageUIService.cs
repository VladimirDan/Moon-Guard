using System;

namespace Code.Meta.UI.HUD.ScoreHolder.Service
{
    public class StorageUIService : IStorageUIService
    {
        public event Action CurrentScoreChange;
        public event Action HighScoreChange;
        
        private float _currentScore;
        public float CurrentScore => _currentScore;
        
        private float _highScore;
        public float HighScore => _highScore;

        public void UpdateCurrentScore(float score)
        {
            if (Math.Abs(score - _currentScore) > float.Epsilon)
            {
                _currentScore = score;
                CurrentScoreChange?.Invoke();
            }
        }
        
        public void UpdateHighScore(float score)
        {
            if (Math.Abs(score - _highScore) > float.Epsilon)
            {
                _highScore = score;
                HighScoreChange?.Invoke();
            }
        }

        public void Cleanup()
        {
            _currentScore = 0;
            _highScore = 0;

            CurrentScoreChange = null;
            HighScoreChange = null;
        }
    }
}