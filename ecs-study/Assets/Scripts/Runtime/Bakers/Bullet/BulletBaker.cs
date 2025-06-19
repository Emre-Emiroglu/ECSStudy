using Runtime.Authorings.Bullet;
using Runtime.Components.Bullet;
using Unity.Entities;

namespace Runtime.Bakers.Bullet
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
                MovementSpeed = authoring.MovementSpeed
            });
            
            AddComponent(bulletEntity, new BulletAutoDestroyData
            {
                AutoDestroyDuration = authoring.AutoDestroyDuration
            });
        }
        #endregion
    }
}