using Code.Gameplay.Features.Score.Systems;
using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;
using Code.Meta.UI.HUD.ScoreHolder.Systems;

namespace Code.Gameplay.Features.Score
{
    public class ScoreFeature : Feature
    {
        public ScoreFeature(ISystemFactory systemFactory)
        { 
            Add(systemFactory.Create<InitializeCurrentScoreSystem>());
            Add(systemFactory.Create<UpdateHighScoreSystem>());
            Add(systemFactory.Create<RefreshCurrentScoreSystem>());
        }
    }
}