using Runtime.Components;
using Runtime.Input;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Systems
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class PlayerInputSystem : SystemBase
    {
        #region Fields
        private InputActions _inputActions;
        #endregion

        #region Core
        protected override void OnCreate()
        {
            _inputActions = new InputActions();
            
            RequireForUpdate<PlayerInputData>();
        }
        protected override void OnStartRunning() => _inputActions.Enable();
        protected override void OnStopRunning() => _inputActions.Disable();
        protected override void OnUpdate()
        {
            Vector2 movementValue = _inputActions.PC.Movement.ReadValue<Vector2>();
            Vector2 rotationValue = _inputActions.PC.Rotation.ReadValue<Vector2>();
            
            float3 movementDirection = new float3(movementValue.x, 0f, movementValue.y);
            float3 rotationDirection = new float3(rotationValue.x, 0f, rotationValue.y);

            SystemAPI.SetSingleton(new PlayerInputData
            {
                MovementDirection = movementDirection,
                RotationDirection = rotationDirection
            });
        }
        #endregion
    }
}