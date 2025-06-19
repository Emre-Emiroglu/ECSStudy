using UnityEngine;

namespace Runtime.Authorings.Enemy
{
    public sealed class EnemyAuthoring : MonoBehaviour
    {
        #region Fields
        [Header("Enemy Authoring Fields")]
        [SerializeField] private float chaseSpeed;
        #endregion

        #region Getters
        public float ChaseSpeed => chaseSpeed;
        #endregion
    }
}