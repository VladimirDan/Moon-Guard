using Code.Gameplay.Features.Enchants.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enchants.Registrars
{
    public class EnchantHolderRegistrar : EntityComponentRegistrar
    {
        public EnchantHolder enchantHolder;
        
        public override void RegisterComponents()
        {
            Entity.AddEnchantHolder(enchantHolder);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEnchantHolder)
                Entity.RemoveEnchantHolder();
        }
    }
}