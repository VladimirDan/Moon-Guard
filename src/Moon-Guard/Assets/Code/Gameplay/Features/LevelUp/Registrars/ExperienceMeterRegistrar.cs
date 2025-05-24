using Code.Gameplay.Features.LevelUp.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.LevelUp.Registrars
{
    public class ExperienceMeterRegistrar : EntityComponentRegistrar
    {
        public ExperienceMeter experienceMeter;
        
        public override void RegisterComponents()
        {
            Entity.AddExperienceMeter(experienceMeter);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasExperienceMeter)
            {
                Entity.RemoveExperienceMeter();
            }
        }
    }
}