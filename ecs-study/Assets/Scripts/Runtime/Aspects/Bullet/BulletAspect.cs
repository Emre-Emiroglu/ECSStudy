﻿using Runtime.Components;
using Runtime.Components.Bullet;
using Unity.Entities;
using Unity.Transforms;

namespace Runtime.Aspects.Bullet
{
    public readonly partial struct BulletAspect : IAspect
    {
        #region Fields
        public readonly Entity BulletEntity;
        public readonly RefRO<BulletTag> BulletTag;
        public readonly RefRW<BulletMovementData> BulletMovementData;
        public readonly RefRW<BulletAutoDestroyData> BulletAutoDestroyData;
        public readonly RefRW<LocalTransform> LocalTransform;
        #endregion
    }
}