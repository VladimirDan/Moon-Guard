using Code.Gameplay.Features.Hero.Behaviours;
using Code.Gameplay.Features.LevelUp.Behaviours;
using Code.Infrastructure.View;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HPMeterRegistrar : EntityComponentRegistrar
    {
        public HPMeter HPMeter;
        public EntityBehaviour target;
            
        public override void RegisterComponents()
        {
            Entity.AddHPMeter(HPMeter);
            Entity.AddHPMeterTarget(target);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasHPMeter)
            {
                Entity.RemoveHPMeter();
            }
        }
    }
}