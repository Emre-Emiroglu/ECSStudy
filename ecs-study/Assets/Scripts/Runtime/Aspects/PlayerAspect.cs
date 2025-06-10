using Runtime.Components;
using Unity.Entities;
using Unity.Transforms;

namespace Runtime.Aspects
{
    public readonly partial struct PlayerAspect : IAspect
    {
        #region Fields
        public readonly Entity PlayerEntity;
        public readonly RefRO<PlayerTag> PlayerTag;
        public readonly RefRW<PlayerInputData> PlayerInputData;
        public readonly RefRO<PlayerMovementData> PlayerMovementData;
        public readonly RefRO<PlayerRotationData> PlayerRotationData;
        public readonly RefRO<PlayerShootingData> PlayerShootingData;
        public readonly RefRW<LocalTransform> LocalTransform;
        #endregion
    }
}