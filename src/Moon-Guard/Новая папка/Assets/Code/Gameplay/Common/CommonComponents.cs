using Entitas;
using UnityEngine;

namespace Code.Gameplay.Common
{
    [Game] public class Id : IComponent { public int Value; }
    [Game] public class WorldPosition : IComponent {public Vector2 Value; }
    [Game] public class TransformComponent : IComponent { public Transform Value; }
}