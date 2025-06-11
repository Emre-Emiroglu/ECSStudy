using UnityEngine;

namespace Runtime.Authorings
{
    public sealed class BulletAuthoring : MonoBehaviour
    {
        #region Fields
        [Header("Bullet Authoring Fields")]
        [SerializeField] private float speed;
        [SerializeField] private float lifetime;
        #endregion

        #region Getters
        public float Speed => speed;
        public float Lifetime => lifetime;
        #endregion
    }
}