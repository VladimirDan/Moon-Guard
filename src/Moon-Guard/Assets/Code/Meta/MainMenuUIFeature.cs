using Code.Common.Destruct;
using Code.Infrastructure.Systems;
using Code.Meta.UI.HUD.ScoreHolder.Systems;

namespace Code.Meta
{
    public class MainMenuUIFeature : Feature
    {
        public MainMenuUIFeature(ISystemFactory systems)
        {
            Add(systems.Create<RefreshHighScoreSystem>());
            Add(systems.Create<RefreshCurrentScoreSystem>());

            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}