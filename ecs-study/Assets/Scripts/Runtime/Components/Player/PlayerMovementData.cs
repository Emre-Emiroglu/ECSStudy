using Unity.Entities;

namespace Runtime.Components.Player
{
    public struct PlayerMovementData : IComponentData
    {
        #region Fields
        public float MovementSpeed;
        #endregion
    }
}