using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using UnityEngine;

namespace Code.Gameplay.Features.PlayerShip.Registrars
{
    public class PlayerShipRegistrar : MonoBehaviour
    {
        private GameEntity _entity;
        public float speed = 2;
        
        private void Awake()
        {
            _entity = CreateEntity
                .Empty()
                .AddTransform(transform)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(speed)
                .With(x => x.isHero = true)
                ;
        }
    }
}