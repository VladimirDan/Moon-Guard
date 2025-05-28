using Code.Gameplay.Features.Armaments.Systems;
using Code.Gameplay.Features.GameOver.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.GameOver
{
    public class GameOverFeature : Feature
    {
        public GameOverFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<GameOverOnHeroDeath>());
            Add(systemFactory.Create<GameOverOnMoonDeath>());
        }
    }
}