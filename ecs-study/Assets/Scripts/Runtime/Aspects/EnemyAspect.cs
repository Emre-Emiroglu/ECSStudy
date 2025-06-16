using Runtime.Components;
using Unity.Entities;

namespace Runtime.Aspects
{
    public readonly partial struct EnemyAspect : IAspect
    {
        #region Fields
        public readonly Entity EnemyEntity;
        public readonly RefRO<EnemyTag> EnemyTag;
        public readonly RefRO<EnemyChaseData> EnemyChaseData;
        #endregion
    }
}