using System.Collections.Generic;
using Code.Gameplay.Features.Enchants.UIFactories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class EnchantHolder : MonoBehaviour
    {
        public Transform enchantLayout;
        private IEnchantUIFactory _factory;
        private readonly List<Enchant> _enchants = new();

        [Inject]
        private void Construct(IEnchantUIFactory factory) =>
            _factory = factory;
        
        public void AddEnchant(EnchantTypeId enchantTypeId)
        {
            if (EnchantAlreadyHeld(enchantTypeId))
                return;
            
            Enchant enchant = _factory.CreateEnchant(enchantLayout, enchantTypeId);

            _enchants.Add(enchant);
        }

        public void RemoveEnchant(EnchantTypeId enchantTypeId)
        {
            Enchant enchant = _enchants.Find(enchant => enchant.id == enchantTypeId);

            if (enchant != null)
            {
                _enchants.Remove(enchant);
                Destroy(enchant.gameObject);
            }
        }

        private bool EnchantAlreadyHeld(EnchantTypeId enchantTypeId)
        {
            return _enchants.Find(x => x.id == enchantTypeId) != null;
        }
    }
}