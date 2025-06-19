using UnityEngine;

namespace Runtime.Authorings.Bullet
{
    public sealed class BulletAuthoring : MonoBehaviour
    {
        #region Fields
        [Header("Bullet Authoring Fields")]
        [SerializeField] private float movementSpeed;
        [SerializeField] private float autoDestroyDuration;
        #endregion

        #region Getters
        public float MovementSpeed => movementSpeed;
        public float AutoDestroyDuration => autoDestroyDuration;
        #endregion
    }
}