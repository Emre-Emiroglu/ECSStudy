using Unity.Entities;

namespace Runtime.Components.Player
{
    public struct PlayerRotationData : IComponentData
    {
        #region Fields
        public float RotationSpeed;
        #endregion
    }
}