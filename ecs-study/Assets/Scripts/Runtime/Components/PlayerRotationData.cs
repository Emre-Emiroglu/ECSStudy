using Unity.Entities;

namespace Runtime.Components
{
    public struct PlayerRotationData : IComponentData
    {
        #region Fields
        public float RotationSpeed;
        #endregion
    }
}