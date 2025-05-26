using Code.Common.Entity;
using Entitas;

namespace Code.Gameplay.Input.Systems
{
  public class InitializeInputSystem : IInitializeSystem
  {
    public void Initialize()
    {
      Code.Common.Entity.CreateInputEntity.Empty()
        .isInput = true;
    }
  }
}