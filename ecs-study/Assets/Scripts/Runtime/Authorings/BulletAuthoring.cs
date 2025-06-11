using UnityEngine;

namespace Runtime.Authorings
{
    public sealed class BulletAuthoring : MonoBehaviour
    {
        #region Fields
        [Header("Bullet Authoring Fields")]
        [SerializeField] private float speed;
        #endregion

        #region Getters
        public float Speed => speed;
        #endregion
    }
}