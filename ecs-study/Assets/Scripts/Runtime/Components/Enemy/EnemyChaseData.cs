using Unity.Entities;

namespace Runtime.Components.Enemy
{
    public struct EnemyChaseData : IComponentData
    {
        #region Fields
        public float ChaseSpeed;
        #endregion
    }
}