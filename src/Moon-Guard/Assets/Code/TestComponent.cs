using Entitas;
using UnityEngine;

namespace Code.Gameplay
{
    public class Id : IComponent { public int Value; }
    public class WorldPosition : IComponent { public Vector3 Value; }

    class CheckImprovements
    {
        public CheckImprovements()
        {
            GameEntity entity = null;

            int id = entity.Id;

            entity
                .AddId(1)
                .AddWorldPosition(Vector3.zero);
        }
    }
}