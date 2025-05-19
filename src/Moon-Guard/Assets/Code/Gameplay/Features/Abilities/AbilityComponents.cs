using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities
{
    [Game] public class AbilityIdComponent : IComponent { public AbilityId Value; }
    [Game] public class LaserShooter : IComponent { }
    [Game] public class LaserShotAbility : IComponent { }
    [Game] public class LaserShotTarget : IComponent { public Vector2 Value; }
}