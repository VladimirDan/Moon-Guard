using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities
{
    [Game] public class AbilityIdComponent : IComponent { public AbilityId Value; }
    [Game] public class ParentAbility : IComponent { [EntityIndex] public AbilityId Value; }
    [Game] public class LaserShooter : IComponent { }
    [Game] public class LaserShotAbility : IComponent { }
    [Game] public class LaserShotTarget : IComponent { public Vector2 Value; }
    
    [Game] public class UpgradeRequest : IComponent { }
    [Game] public class RecreatedOnUpgrade : IComponent { }
}