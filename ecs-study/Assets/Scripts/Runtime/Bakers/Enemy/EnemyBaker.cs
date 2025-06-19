using Runtime.Authorings.Enemy;
using Runtime.Components.Enemy;
using Unity.Entities;

namespace Runtime.Bakers.Enemy
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