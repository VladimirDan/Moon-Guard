using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitMouseInputSystem: IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<InputEntity> _inputs;

        public EmitMouseInputSystem(InputContext game, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(InputMatcher.Input);
        }
    
        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                input.ReplaceCursorPositionInput(_inputService.GetWorldMousePosition());
            }
        }
    }
}