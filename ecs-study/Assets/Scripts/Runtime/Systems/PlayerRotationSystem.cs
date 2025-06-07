using Runtime.Aspects;
using Runtime.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Runtime.Systems
{
    public partial struct PlayerRotationSystem : ISystem
    {
        #region Core
        [BurstCompile]
        public void OnCreate(ref SystemState state) => state.RequireForUpdate<PlayerInputData>();
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (!SystemAPI.HasSingleton<PlayerInputData>())
                return;
            
            float3 rotationDirection = SystemAPI.GetSingleton<PlayerInputData>().RotationDirection;
            
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (PlayerAspect playerAspect in SystemAPI.Query<PlayerAspect>().WithAll<PlayerTag>())
            {
                float speed = playerAspect.PlayerRotationData.ValueRO.RotationSpeed;
                
            }
        }
        #endregion
    }
}