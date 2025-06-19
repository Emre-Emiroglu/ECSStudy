using Runtime.Components.Player;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using PlayerAspect = Runtime.Aspects.Player.PlayerAspect;

namespace Runtime.Systems.Player
{
    [BurstCompile]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct PlayerMovementSystem : ISystem
    {
        #region Core
        [BurstCompile]
        public void OnCreate(ref SystemState state) => state.RequireForUpdate<PlayerInputData>();
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (!SystemAPI.HasSingleton<PlayerInputData>())
                return;

            float3 movementDirection = SystemAPI.GetSingleton<PlayerInputData>().MovementDirection;
            
            float deltaTime = SystemAPI.Time.DeltaTime;

            foreach (PlayerAspect playerAspect in SystemAPI.Query<PlayerAspect>().WithAll<PlayerTag>())
            {
                float speed = playerAspect.PlayerMovementData.ValueRO.MovementSpeed;
                
                playerAspect.LocalTransform.ValueRW.Position += movementDirection * speed * deltaTime;
            }
        }
        #endregion
    }
}