using Code.Common;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private Vector3 _farPosition = new (-999, 999, 0);

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }
        
        public EntityBehaviour CreateViewForEntity(GameEntity entity)
        {
            EntityBehaviour prefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                prefab,
                position: _farPosition,
                Quaternion.identity, 
                parentTransform: null);
            
            view.SetEntity(entity);

            return view;
        }
        
        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
        {
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                entity.ViewPrefab,
                position: _farPosition,
                Quaternion.identity, 
                parentTransform: null);
            
            view.SetEntity(entity);

            return view;
        }
    }
}