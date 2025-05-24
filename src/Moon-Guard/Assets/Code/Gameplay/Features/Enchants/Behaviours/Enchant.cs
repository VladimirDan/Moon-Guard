using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class Enchant : MonoBehaviour
    {
        public Image icon;
        public EnchantTypeId id;

        public void Set(EnchantConfig enchantConfig)
        {
            icon.sprite = enchantConfig.icon;
            id = enchantConfig.TypeId;
        }
    }
}