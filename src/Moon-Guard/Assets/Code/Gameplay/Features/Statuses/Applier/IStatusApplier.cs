namespace Code.Gameplay.Features.Statuses.Applier
{
    public interface IStatusApplier
    {
        GameEntity ApplyStatus(StatusSetup statusSetup, int producerId, int targetId);
    }
}