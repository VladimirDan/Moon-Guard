using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View;
using Entitas;

namespace Code.Gameplay.Features.Hero
{
  [Game] public class Hero : IComponent { }
  [Game] public class Moon : IComponent { }
  [Game] public class HeroAnimatorComponent : IComponent { public HeroAnimator Value; }
  [Game] public class HPMeterComponent : IComponent { public HPMeter Value; }
  [Game] public class HPMeterTarget : IComponent { public EntityBehaviour Value; }
}