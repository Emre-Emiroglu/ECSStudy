using Unity.Entities;
using Unity.Mathematics;

namespace Runtime.Components
{
    public struct PlayerInputData : IComponentData
    {
        #region Fields
        public float3 MovementDirection;
        public float3 RotationDirection;
        public bool IsShooting;
        #endregion
    }
}