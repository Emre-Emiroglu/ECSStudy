using Unity.Entities;

namespace Runtime.Components.Bullet
{
    public struct BulletAutoDestroyData : IComponentData
    {
        #region Fields
        public float AutoDestroyDuration;
        #endregion
    }
}