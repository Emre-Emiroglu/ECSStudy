using Unity.Entities;

namespace Runtime.Components
{
    public struct BulletLifetimeData : IComponentData
    {
        #region Fields
        public float Lifetime;
        #endregion
    }
}