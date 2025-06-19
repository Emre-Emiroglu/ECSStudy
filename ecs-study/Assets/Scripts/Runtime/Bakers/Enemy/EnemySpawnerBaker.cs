using Runtime.Authorings.Enemy;
using Runtime.Components.Enemy;
using Unity.Entities;

namespace Runtime.Bakers.Enemy
{
    public sealed class EnemySpawnerBaker : Baker<EnemySpawnerAuthorings>
    {
        #region Core
        public override void Bake(EnemySpawnerAuthorings authoring)
        {
            Entity enemySpawnerEntity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(enemySpawnerEntity, new EnemySpawnerData
            {
                SpawnRate = authoring.SpawnRate,
                MaxSpawnCount = authoring.MaxSpawnCount,
                EnemyEntity = GetEntity(authoring.EnemyPrefab, TransformUsageFlags.Dynamic)
            });
        }
        #endregion
    }
}