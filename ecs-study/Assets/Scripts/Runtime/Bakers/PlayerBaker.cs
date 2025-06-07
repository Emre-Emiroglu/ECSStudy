using Runtime.Authorings;
using Runtime.Components;
using Unity.Entities;

namespace Runtime.Bakers
{
    public sealed class PlayerBaker : Baker<PlayerAuthoring>
    {
        #region Core
        public override void Bake(PlayerAuthoring playerAuthoring)
        {
            Entity playerEntity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent<PlayerTag>(playerEntity);
            
            AddComponent(playerEntity, new PlayerMovementData(playerAuthoring.MovementSpeed));
            AddComponent(playerEntity, new PlayerRotationData(playerAuthoring.RotationSpeed));
            AddComponent(playerEntity, new PlayerShootingData(playerAuthoring.FireRate));
        }
        #endregion
    }
}