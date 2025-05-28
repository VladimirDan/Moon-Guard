using System;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.GameOver.UI
{
    public class PauseButton : MonoBehaviour
    {
        public Button pauseButton;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IWindowService windowService)
        {
            _windowService = windowService;
        }
        
        public void Start()
        {
            pauseButton.onClick.AddListener(Pause);
        }
        
        private void Pause()
        {
            _windowService.Open(WindowId.GamePauseWindow);
        }
    }
}