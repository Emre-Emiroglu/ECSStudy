using Unity.Entities;

namespace Runtime.Components
{
    public struct BulletAutoDestroyData : IComponentData
    {
        #region Fields
        public float AutoDestroyDuration;
        #endregion
    }
}