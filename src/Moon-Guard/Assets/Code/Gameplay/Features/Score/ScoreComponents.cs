using Code.Progress;
using Entitas;

namespace Code.Gameplay.Features.Score
{
    [Game] public class Score : ISavedComponent { }
    [Game] public class HighScore : ISavedComponent { public float Value; }
    [Game] public class CurrentScore : IComponent { public float Value; }
}