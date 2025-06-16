using Runtime.Authorings;
using Runtime.Components;
using Unity.Entities;

namespace Runtime.Bakers
{
    public sealed class EnemyBaker : Baker<EnemyAuthoring>
    {
        #region Core
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity enemyEntity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent<EnemyTag>(enemyEntity);
            
            AddComponent(enemyEntity, new EnemyChaseData
            {
                ChaseSpeed = authoring.ChaseSpeed,
            });
        }
        #endregion
    }
}