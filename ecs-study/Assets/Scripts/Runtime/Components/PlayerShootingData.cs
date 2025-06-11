using Unity.Entities;

namespace Runtime.Components
{
    public struct PlayerShootingData : IComponentData
    {
        #region Fields
        public float FireRate;
        public Entity BulletEntity;
        #endregion
    }
}