using Code.Common.Destruct;
using Code.Infrastructure.Systems;


namespace Code.Meta
{
  public class MainMenuFeature : Feature
  {
    public MainMenuFeature(ISystemFactory systems)
    {
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}