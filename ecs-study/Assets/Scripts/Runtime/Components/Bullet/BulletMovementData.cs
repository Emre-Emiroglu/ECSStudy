using Unity.Entities;
using Unity.Mathematics;

namespace Runtime.Components.Bullet
{
    public struct BulletMovementData : IComponentData
    {
        #region Fields
        public float MovementSpeed;
        public float3 Velocity;
        #endregion
    }
}