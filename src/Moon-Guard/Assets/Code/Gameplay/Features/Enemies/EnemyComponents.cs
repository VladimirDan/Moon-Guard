﻿using Code.Gameplay.Features.Enemies.Behaviours;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies
{
  [Game] public class Enemy : IComponent { }
  [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
  [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
  [Game] public class EnemyMoveTargetComponent : IComponent { public Vector2 Value; }
}