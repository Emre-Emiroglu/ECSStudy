using Runtime.Aspects;
using Runtime.Components;
using Unity.Burst;
using Unity.Entities;

namespace Runtime.Systems
{
    public partial struct BulletAutoDestroySystem : ISystem
    {
        #region Core
        [BurstCompile]
        public void OnCreate(ref SystemState state) => state.RequireForUpdate<BulletLifetimeData>();
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            
            EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

            foreach (BulletAspect bulletAspect in SystemAPI.Query<BulletAspect>().WithAll<BulletTag>())
            {
                bulletAspect.BulletLifetimeData.ValueRW.Lifetime -= deltaTime;

                if (bulletAspect.BulletLifetimeData.ValueRO.Lifetime <= 0f)
                {
                    entityCommandBuffer.DestroyEntity(bulletAspect.BulletEntity);
                }
            }
            
            entityCommandBuffer.Playback(state.EntityManager);
            entityCommandBuffer.Dispose();
        }
        #endregion
    }
}