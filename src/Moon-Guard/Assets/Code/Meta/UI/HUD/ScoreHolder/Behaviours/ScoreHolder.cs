using Code.Meta.UI.HUD.ScoreHolder.Service;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Meta.UI.HUD.ScoreHolder.Behaviours
{
    public class ScoreHolder : MonoBehaviour
    {
        public TextMeshProUGUI currentScore;
        public TextMeshProUGUI highScore;
        private IStorageUIService _storageUIService;

        [Inject]
        private void Construct(IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
        }

        private void Start()
        {
            _storageUIService.CurrentScoreChange += UpdateCurrentScore;
            _storageUIService.HighScoreChange += UpdateHighScore;

            UpdateCurrentScore();
        }

        private void UpdateCurrentScore()
        {
            if (currentScore != null)
                currentScore.text = _storageUIService.CurrentScore.ToString();
        }

        private void UpdateHighScore()
        {
            if (highScore != null)
                highScore.text = _storageUIService.HighScore.ToString();
        }

        private void OnDestroy()
        {
            _storageUIService.CurrentScoreChange -= UpdateCurrentScore;
            _storageUIService.HighScoreChange -= UpdateHighScore;
        }
    }
}