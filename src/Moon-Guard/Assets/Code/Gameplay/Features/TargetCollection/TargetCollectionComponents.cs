using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection
{
    [Game] public class TargetsBuffer : IComponent { public List<int> Value; }
    [Game] public class ProcessedTargetsBuffer : IComponent { public List<int> Value; }
    [Game] public class CollectTargetsInterval : IComponent { public float Value; }
    [Game] public class CollectTargetsTimer : IComponent { public float Value; }
    [Game] public class TargetsSelectionRadius : IComponent { public float Value; }
    [Game] public class LayerMask : IComponent { public int Value; }
    [Game] public class EnemyLayerMask : IComponent { public int Value; }
    [Game] public class ReadyToCollectTargets : IComponent { }
    [Game] public class CollectingTargetsContinuously : IComponent { }
    [Game] public class Reached : IComponent { }
}