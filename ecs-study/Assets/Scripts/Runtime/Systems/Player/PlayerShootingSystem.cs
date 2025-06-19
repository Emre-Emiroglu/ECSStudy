using Runtime.Components.Player;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using PlayerAspect = Runtime.Aspects.Player.PlayerAspect;

namespace Runtime.Systems.Player
{
    [BurstCompile]
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial struct PlayerShootingSystem : ISystem
    {
        #region Fields
        private float _time;
        #endregion
        
        #region Core
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndSimulationEntityCommandBufferSystem.Singleton>();
            state.RequireForUpdate<PlayerInputData>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (!SystemAPI.HasSingleton<PlayerInputData>())
                return;

            PlayerInputData playerInput = SystemAPI.GetSingleton<PlayerInputData>();
            if (!playerInput.IsShooting)
            {
                _time = 0f;
                return;
            }
            
            _time += SystemAPI.Time.DeltaTime;
            
            bool canShoot = false;

            foreach (PlayerAspect playerAspect in SystemAPI.Query<PlayerAspect>().WithAll<PlayerTag>())
            {
                float fireRate = playerAspect.PlayerShootingData.ValueRO.FireRate;

                if (_time <= fireRate)
                    continue;
                
                canShoot = true;
                
                break;
            }
            
            if (!canShoot)
                return;

            _time = 0f;

            EndSimulationEntityCommandBufferSystem.Singleton ecbSingleton =
                SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            EntityCommandBuffer entityCommandBuffer = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);

            foreach (PlayerAspect playerAspect in SystemAPI.Query<PlayerAspect>().WithAll<PlayerTag>())
            {
                Entity bulletPrefab = playerAspect.PlayerShootingData.ValueRO.BulletEntity;

                Entity bullet = entityCommandBuffer.Instantiate(bulletPrefab);

                entityCommandBuffer.SetComponent(bullet, new LocalTransform
                {
                    Position = playerAspect.LocalTransform.ValueRO.Position,
                    Rotation = playerAspect.LocalTransform.ValueRO.Rotation,
                    Scale = 1f
                });
            }
        }
        #endregion
    }
}