using Code.Gameplay.Input.Service;
using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Input
{
  public class InputFeature : Feature
  {
    private readonly ISystemFactory _systemFactory;

    public InputFeature(ISystemFactory systemFactory)
    {
      _systemFactory = systemFactory;
      Add(_systemFactory.Create<InitializeInputSystem>());
      Add(_systemFactory.Create<EmitMouseInputSystem>());
    }
  }
}