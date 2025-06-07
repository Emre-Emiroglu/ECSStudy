using Runtime.Components;
using Unity.Entities;

namespace Runtime.Aspects
{
    public readonly partial struct PlayerAspect : IAspect
    {
        #region Fields
        private readonly Entity _playerEntity;
        private readonly RefRO<PlayerTag> _playerTag;
        private readonly RefRO<PlayerInputData> _playerInputData;
        private readonly RefRO<PlayerMovementData> _playerMovementData;
        private readonly RefRO<PlayerRotationData> _playerRotationData;
        private readonly RefRO<PlayerShootingData> _playerShootingData;
        #endregion
    }
}