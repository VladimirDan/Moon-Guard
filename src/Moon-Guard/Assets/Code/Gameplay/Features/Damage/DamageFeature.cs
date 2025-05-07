using Code.Gameplay.Features.Damage.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Damage
{
    public class DamageFeature : Feature
    {
        public DamageFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DealDamageToTargetsSystem>());
            
        }
    }
}