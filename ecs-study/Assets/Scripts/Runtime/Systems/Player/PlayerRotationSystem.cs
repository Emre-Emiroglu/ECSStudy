using Runtime.Components.Player;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using PlayerAspect = Runtime.Aspects.Player.PlayerAspect;

namespace Runtime.Systems.Player
{
    [BurstCompile]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
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
                
                float3 playerPos = playerAspect.LocalTransform.ValueRO.Position;
                
                float3 lookDir = math.normalize(rotationDirection - playerPos);

                quaternion targetRot = quaternion.LookRotationSafe(new float3(lookDir.x, 0, lookDir.z), math.up());
                quaternion currentRot = playerAspect.LocalTransform.ValueRO.Rotation;

                playerAspect.LocalTransform.ValueRW.Rotation = math.slerp(currentRot, targetRot, deltaTime * speed);
            }
        }
        #endregion
    }
}