using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp
{
    [CreateAssetMenu(menuName = "Moon Guard/LevelUpConfig Config", fileName = "LevelUpConfig")]
    public class LevelUpConfig : ScriptableObject
    {
        public int maxLevel;
        public List<float> ExperienceForLevel;
    }
}