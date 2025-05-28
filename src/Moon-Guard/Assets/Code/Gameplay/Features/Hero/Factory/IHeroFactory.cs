using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public interface IHeroFactory
    {
        GameEntity CreateHero(Vector3 pos);
        GameEntity CreateMoon(Vector3 pos);
    }
}