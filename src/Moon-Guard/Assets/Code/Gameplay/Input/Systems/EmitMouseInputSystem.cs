﻿using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitMouseInputSystem: IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public EmitMouseInputSystem(GameContext game, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }
    
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceCursorPositionInput(_inputService.GetWorldMousePosition());
            }
        }
    }
}