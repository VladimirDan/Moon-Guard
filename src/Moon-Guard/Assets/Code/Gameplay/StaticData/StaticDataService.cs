using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<AbilityId, AbilityConfig> _abilityById;
    private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;
    private Dictionary<WindowId, GameObject> _windowPrefabsById;
    
    public void LoadAll()
    {
      LoadAbilities();
      LoadEnchants();
      //LoadWindows();
    }

    public AbilityConfig GetAbilityConfig(AbilityId abilityId)
    {
      if (_abilityById.TryGetValue(abilityId, out AbilityConfig config))
        return config;

      throw new Exception($"Ability config {abilityId} was not found");
    }
    
    public GameObject GetWindowPrefab(WindowId id) =>
      _windowPrefabsById.TryGetValue(id, out GameObject prefab)
        ? prefab
        : throw new Exception($"Prefab config for window {id} was not found");

    public EnchantConfig GetEnchantConfig(EnchantTypeId typeId)
    {
      if (_enchantById.TryGetValue(typeId, out EnchantConfig config))
        return config;

      throw new Exception($"Enchant config for {typeId} was not found");
    }
    
    public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
    {
      AbilityConfig config = GetAbilityConfig(abilityId);

      if (level > config.levels.Count)
        level = config.levels.Count;

      return config.levels[level - 1];
    }
    
    private void LoadAbilities()
    {
      _abilityById = Resources.LoadAll<AbilityConfig>("Configs/Abilities/LaserShotConfig")
        .ToDictionary(x => x.abilityId, x => x);
    }
    
    private void LoadEnchants()
    {
      _enchantById = Resources
        .LoadAll<EnchantConfig>("Configs/Enchants")
        .ToDictionary(x => x.TypeId, x => x);
    }
    
    private void LoadWindows()
    {
      _windowPrefabsById = Resources
        .Load<WindowsConfig>("Configs/Windows/windowsConfig")
        .WindowConfigs
        .ToDictionary(x => x.Id, x => x.Prefab);
    }
    
  }
}