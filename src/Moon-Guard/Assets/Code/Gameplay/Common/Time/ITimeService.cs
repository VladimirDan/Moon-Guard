using System;

namespace Code.Gameplay.Common.Time
{
  public interface ITimeService
  {
    bool isPaused { get; }
    float DeltaTime { get; }
    DateTime UtcNow { get; }
    void StopTime();
    void StartTime();
  }
}