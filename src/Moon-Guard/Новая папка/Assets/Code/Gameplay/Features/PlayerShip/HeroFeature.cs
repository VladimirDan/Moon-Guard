using Unity.VisualScripting;

namespace Code.Gameplay.Features.PlayerShip.Systems
{
    public class HeroFeature : Feature
    {
        public HeroFeature(GameContext gameContext)
        {
            Add(new SetHeroDirectionByInputSystem(gameContext));
        }
    }
}