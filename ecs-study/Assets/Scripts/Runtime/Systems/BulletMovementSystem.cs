using Runtime.Aspects;
using Runtime.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Runtime.Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct BulletMovementSystem : ISystem
    {
        #region Core
        [BurstCompile]
        public void OnCreate(ref SystemState state) => state.RequireForUpdate<BulletMovementData>();
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            
            foreach (BulletAspect bulletAspect in SystemAPI.Query<BulletAspect>().WithAll<BulletTag>())
            {
                if (bulletAspect.BulletMovementData.ValueRO.Velocity.Equals(float3.zero))
                {
                    float3 forward = math.forward(bulletAspect.LocalTransform.ValueRO.Rotation);

                    bulletAspect.BulletMovementData.ValueRW.Velocity =
                        forward * bulletAspect.BulletMovementData.ValueRO.Speed;
                }

                bulletAspect.LocalTransform.ValueRW.Position +=
                    bulletAspect.BulletMovementData.ValueRO.Velocity * deltaTime;
            }
        }
        #endregion
    }
}