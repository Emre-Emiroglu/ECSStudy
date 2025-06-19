using UnityEngine;

namespace Runtime.Authorings.Enemy
{
    public sealed class EnemySpawnerAuthorings : MonoBehaviour
    {
        #region Fields
        [Header("Enemy Spawner Authoring Fields")]
        [Range(0.01f, 1f)] [SerializeField] private float spawnRate;
        [Range(1, 100000)] [SerializeField] private int maxSpawnCount;
        [SerializeField] private GameObject enemyPrefab;
        #endregion

        #region Getters
        public float SpawnRate => spawnRate;
        public int MaxSpawnCount => maxSpawnCount;
        public GameObject EnemyPrefab => enemyPrefab;
        #endregion
    }
}