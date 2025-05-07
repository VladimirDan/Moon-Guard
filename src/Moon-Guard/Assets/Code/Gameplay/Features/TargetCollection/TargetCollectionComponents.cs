using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.TargetCollection
{
    [Game] public class TargetsBuffer : IComponent { public List<int> Value; }
    [Game] public class CollectTargetsInterval : IComponent { public float Value; }
    [Game] public class CollectTargetsTimer : IComponent { public float Value; }
    [Game] public class TargetsSelectionRadius : IComponent { public float Value; }
    [Game] public class LayerMask : IComponent { public int Value; }
    [Game] public class ReadyToCollectTargets : IComponent { }
}