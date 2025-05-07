using Code.Gameplay.Features.Enemies.Systems;
using Code.Gameplay.Features.Movement.Systems;
using Entitas;

namespace Code.Gameplay.Features.LifeTime
{
    [Game] public class CurrentHP : IComponent { public float Value; }
    [Game] public class FullHP : IComponent { public float Value; }
    [Game] public class Dead : IComponent { }
    [Game] public class ProcessingDeath : IComponent { }
}