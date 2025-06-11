using Runtime.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

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
            
            foreach ((RefRW<LocalTransform> transform, RefRW<BulletMovementData> movementData) in 
                     SystemAPI.Query<RefRW<LocalTransform>, RefRW<BulletMovementData>>()
                         .WithAll<BulletTag>())
            {
                if (movementData.ValueRO.Velocity.Equals(float3.zero))
                {
                    float3 forward = math.forward(transform.ValueRO.Rotation);
                    movementData.ValueRW.Velocity = forward * movementData.ValueRO.Speed;
                }
                
                transform.ValueRW.Position += movementData.ValueRO.Velocity * deltaTime;
            }
        }
        #endregion
    }
}