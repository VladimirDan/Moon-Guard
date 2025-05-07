using Code.Common.Destruct;
using Code.Gameplay.Features.Damage;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.LifeTime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Gameplay.TargetCollection;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
  public class BattleFeature : Feature
  {
    private readonly ISystemFactory _systemFactory;

    public BattleFeature(ISystemFactory systemFactory)
    {
      _systemFactory = systemFactory;
      Add(_systemFactory.Create<InputFeature>());
      
      Add(_systemFactory.Create<HeroFeature>());

      Add(_systemFactory.Create<EnemyFeature>());
      
      Add(_systemFactory.Create<DeathFeature>());
      
      Add(_systemFactory.Create<MovementFeature>());
      
      Add(_systemFactory.Create<CollectTargetsFeature>());
      
      Add(_systemFactory.Create<DamageFeature>());
      
      Add(_systemFactory.Create<ProcessDestructedFeature>());
    }
  }
}