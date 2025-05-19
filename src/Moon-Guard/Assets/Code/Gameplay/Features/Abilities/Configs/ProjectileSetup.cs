using System;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    public class ProjectileSetup
    {
        public float speed;
        public int pierce = 1;
        public float contactRadius;
        public float lifeTime;
    }
}