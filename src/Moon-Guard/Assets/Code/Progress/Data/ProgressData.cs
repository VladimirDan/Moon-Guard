using System;
using Newtonsoft.Json;

namespace Code.Progress.Data
{
  public class ProgressData
  {
    [JsonProperty ("e")] public EntityData entityData = new();
    [JsonProperty ("at")] public int HighScore;
  }
  
}