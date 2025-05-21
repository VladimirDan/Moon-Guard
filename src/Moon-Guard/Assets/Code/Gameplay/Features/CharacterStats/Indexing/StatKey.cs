using Code.Gameplay.Features.Statuses.Indexing;

namespace Code.Gameplay.Features.CharacterStats.Indexing
{
    public struct StatKey
    {
        public readonly int TargetId;
        public readonly Stats stat;

        public StatKey(int targetId, Stats stat)
        {
            TargetId = targetId;
            this.stat = stat;
        }
    }
}