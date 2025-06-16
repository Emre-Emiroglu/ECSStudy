using Unity.Entities;
using Unity.Mathematics;

namespace Runtime.Components
{
    public struct BulletMovementData : IComponentData
    {
        #region Fields
        public float MovementSpeed;
        public float3 Velocity;
        #endregion
    }
}