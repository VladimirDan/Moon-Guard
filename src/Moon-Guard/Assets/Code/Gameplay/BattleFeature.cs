using Code.Common.Destruct;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Armaments;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.LifeTime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Factory;
using Code.Gameplay.Features.Statuses.Systems;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
  public class BattleFeature : Feature
  {
    private readonly ISystemFactory _systemFactory;

    public BattleFeature(ISystemFactory systemFactory)
    {
      _systemFactory = systemFactory;
      
      Add(_systemFactory.Create<InputFeature>());
      Add(_systemFactory.Create<BindViewFeature>());
      
      Add(_systemFactory.Create<HeroFeature>());

      Add(_systemFactory.Create<EnemyFeature>());
      
      Add(_systemFactory.Create<DeathFeature>());
      
      Add(_systemFactory.Create<MovementFeature>());
      Add(_systemFactory.Create<AbilityFeature>());
      Add(_systemFactory.Create<ArmamentFeature>());
      
      Add(_systemFactory.Create<CollectTargetsFeature>());
      Add(_systemFactory.Create<EffectApllicationFeature>());
      
      Add(_systemFactory.Create<EnchantFeature>());
      Add(_systemFactory.Create<EffectFeature>());
      Add(_systemFactory.Create<StatusFeature>());
      Add(_systemFactory.Create<StatsFeature>());
      
      Add(_systemFactory.Create<ProcessDestructedFeature>());
    }
  }
}