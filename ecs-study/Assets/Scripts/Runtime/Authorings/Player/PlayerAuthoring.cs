using UnityEngine;

namespace Runtime.Authorings.Player
{
    public sealed class PlayerAuthoring : MonoBehaviour
    {
        #region Fields
        [Header("Player Authoring Fields")]
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float fireRate;
        [SerializeField] private GameObject bulletPrefab;
        #endregion

        #region Getters
        public float MovementSpeed => movementSpeed;
        public float RotationSpeed => rotationSpeed;
        public float FireRate => fireRate;
        public GameObject BulletPrefab => bulletPrefab;
        #endregion
    }
}