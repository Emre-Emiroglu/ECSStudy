using Unity.Entities;

namespace Runtime.Components
{
    public struct PlayerMovementData : IComponentData
    {
        #region Fields
        public float MovementSpeed;
        #endregion
    }
}