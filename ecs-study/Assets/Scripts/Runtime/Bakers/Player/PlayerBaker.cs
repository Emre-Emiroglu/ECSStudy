using Runtime.Authorings.Player;
using Runtime.Components.Player;
using Unity.Entities;

namespace Runtime.Bakers.Player
{
    public sealed class PlayerBaker : Baker<PlayerAuthoring>
    {
        #region Core
        public override void Bake(PlayerAuthoring playerAuthoring)
        {
            Entity playerEntity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent<PlayerTag>(playerEntity);
            AddComponent<PlayerInputData>(playerEntity);
            
            AddComponent(playerEntity, new PlayerMovementData
            {
                MovementSpeed = playerAuthoring.MovementSpeed
            });
            AddComponent(playerEntity, new PlayerRotationData
            {
                RotationSpeed = playerAuthoring.RotationSpeed
            });
            AddComponent(playerEntity, new PlayerShootingData
            {
                FireRate = playerAuthoring.FireRate,
                BulletEntity =  GetEntity(playerAuthoring.BulletPrefab, TransformUsageFlags.Dynamic)
            });
        }
        #endregion
    }
}