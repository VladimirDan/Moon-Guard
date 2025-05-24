using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Windows;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    AbilityConfig GetAbilityConfig(AbilityId abilityId);
    int MaxLevel();
    float ExperienceForLevel(int level);
    GameObject GetWindowPrefab(WindowId id);
    EnchantConfig GetEnchantConfig(EnchantTypeId typeId);
    LootConfig GetLootConfig(LootTypeId typeId);
    AbilityLevel GetAbilityLevel(AbilityId abilityId, int level);
  }
}