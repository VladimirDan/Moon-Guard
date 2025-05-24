using Entitas;

namespace Code.Gameplay.Features.Loot
{
    [Game] public class Loot : IComponent { }
    [Game] public class Pullable : IComponent { }
    [Game] public class ExpPullable : IComponent { }
    [Game] public class Pulling : IComponent { }
    [Game] public class Collected : IComponent { }
    [Game] public class LootTypeIdComponent : IComponent { public LootTypeId Value; }
    [Game] public class Experience : IComponent { public float Value; }
    [Game] public class PullSpeed : IComponent { public float Value; }
    [Game] public class CollectDistance : IComponent { public float Value; }
    
    [Game] public class LootPoolingRadius : IComponent { public float Value; }
    [Game] public class ExpLootPoolingRadius : IComponent { public float Value; }
}

