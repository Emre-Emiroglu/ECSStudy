using Unity.Entities;

namespace Runtime.Components
{
    public readonly struct PlayerMovementData : IComponentData
    {
        #region Fields
        private readonly float _movementSpeed;
        #endregion

        #region Constructor
        public PlayerMovementData(float movementSpeed) => _movementSpeed = movementSpeed;
        #endregion
    }
}