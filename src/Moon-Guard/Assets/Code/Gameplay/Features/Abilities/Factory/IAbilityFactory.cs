namespace Code.Gameplay.Features.Abilities.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreateLaserShotAbility(int level);
    }
}