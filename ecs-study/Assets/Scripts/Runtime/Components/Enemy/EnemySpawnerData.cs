using Unity.Entities;

namespace Runtime.Components.Enemy
{
    public struct EnemySpawnerData : IComponentData
    {
        #region Fields
        public float SpawnRate;
        public int MaxSpawnCount;
        public Entity EnemyEntity;
        #endregion
    }
}