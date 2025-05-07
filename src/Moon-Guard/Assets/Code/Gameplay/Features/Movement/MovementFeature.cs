using Code.Gameplay.Features.Enemies.Systems;
using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
  public class MovementFeature : Feature
  {
    private ISystemFactory _systemFactory;

    public MovementFeature(ISystemFactory systemFactory)
    {
      _systemFactory = systemFactory;
      Add(_systemFactory.Create<SetMoveTargetByHeroWorldPositionSystem>());
      Add(_systemFactory.Create<SetMoveDirectionByTargetSystem>());
      Add(_systemFactory.Create<DirectionalDeltaMoveSystem>());
      
      Add(_systemFactory.Create<TurnAlongDirection>());
      Add(_systemFactory.Create<UpdateTransformPositionSystem>());
    }
  }
}