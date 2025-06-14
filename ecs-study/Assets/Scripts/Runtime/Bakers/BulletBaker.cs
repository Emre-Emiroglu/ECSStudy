﻿using Runtime.Authorings;
using Runtime.Components;
using Unity.Entities;

namespace Runtime.Bakers
{
    public sealed class BulletBaker : Baker<BulletAuthoring>
    {
        #region Core
        public override void Bake(BulletAuthoring authoring)
        {
            Entity bulletEntity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent<BulletTag>(bulletEntity);

            AddComponent(bulletEntity, new BulletMovementData
            {
                Speed = authoring.Speed
            });
            
            AddComponent(bulletEntity, new BulletLifetimeData
            {
                Lifetime = authoring.Lifetime
            });
        }
        #endregion
    }
}