using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Loot
{
    [CreateAssetMenu(menuName = "Moon Guard/Loot Config", fileName = "lootConfig")]
    public class LootConfig : ScriptableObject
    {
        public LootTypeId lootTypeId;
        public float experience;
        public float pullSpeed;
        public float collectDistance;
        public EntityBehaviour viewPrefab;

        public List<EffectSetup> effectSetups;
        public List<StatusSetup> statusSetups;
    }
}