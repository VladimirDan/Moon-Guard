using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(menuName = "Moon Guard", fileName = "abilitConfig")]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityId abilityId;
        public List<AbilityLevel> levels;
    }
}