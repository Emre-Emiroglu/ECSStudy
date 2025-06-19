using Unity.Entities;
using Unity.Mathematics;

namespace Runtime.Components.Player
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