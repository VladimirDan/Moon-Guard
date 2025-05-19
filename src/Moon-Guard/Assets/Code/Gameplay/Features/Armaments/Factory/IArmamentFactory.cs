using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
    public interface IArmamentFactory
    {
        GameEntity CreateLaserShot(int level, Vector3 pos, int enemyLayerMask);
    }
}