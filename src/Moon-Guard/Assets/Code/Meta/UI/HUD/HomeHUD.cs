using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD
{
    public class HomeHUD : MonoBehaviour
    {
        private const string BattleSceneName = "Game";

        private IGameStateMachine _stateMachine;

        public Button StartBattleButton;
        public Button ExitButton;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine) =>
            _stateMachine = gameStateMachine;

        private void Awake()
        {
            StartBattleButton.onClick.AddListener(EnterBattleLoadingState);
            ExitButton.onClick.AddListener(ExitGame);
        }

        private void EnterBattleLoadingState() =>
            _stateMachine.Enter<LoadingBattleState, string>(BattleSceneName);

        private void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}