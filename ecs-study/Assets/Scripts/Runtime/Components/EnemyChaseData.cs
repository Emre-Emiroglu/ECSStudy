using Unity.Entities;

namespace Runtime.Components
{
    public struct EnemyChaseData : IComponentData
    {
        #region Fields
        public float ChaseSpeed;
        #endregion
    }
}