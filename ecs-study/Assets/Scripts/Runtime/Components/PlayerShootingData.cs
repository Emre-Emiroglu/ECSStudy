using Unity.Entities;

namespace Runtime.Components
{
    public readonly struct PlayerShootingData : IComponentData
    {
        #region Fields
        private readonly float _fireRate;
        #endregion

        #region Constructor
        public PlayerShootingData(float fireRate) => _fireRate = fireRate;
        #endregion
    }
}