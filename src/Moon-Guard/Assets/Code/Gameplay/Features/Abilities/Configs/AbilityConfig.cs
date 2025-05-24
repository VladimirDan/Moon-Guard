using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(menuName = "Moon Guard/abilityConfig", fileName = "abilityConfig")]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityId abilityId;
        public List<AbilityLevel> levels;
    }
}