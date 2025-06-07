using Unity.Entities;

namespace Runtime.Components
{
    public readonly struct PlayerRotationData : IComponentData
    {
        #region Fields
        private readonly float _rotationSpeed;
        #endregion

        #region Constructor
        public PlayerRotationData(float rotationSpeed) => _rotationSpeed = rotationSpeed;
        #endregion
    }
}