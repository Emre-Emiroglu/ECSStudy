using Runtime.Aspects;
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
        protected override void OnCreate() => _inputActions = new InputActions();
        protected override void OnStartRunning() => _inputActions.Enable();
        protected override void OnStopRunning() => _inputActions.Disable();
        protected override void OnUpdate()
        {
            Vector2 movementValue = _inputActions.PC.Movement.ReadValue<Vector2>();
            
            float3 movementDirection = new float3(movementValue.x, 0f, movementValue.y);
            float3 rotationDirection = MouseWorldPositionCalculator.MouseWorldPosition;

            bool isShooting = _inputActions.PC.Shoot.IsPressed();
            
            foreach (PlayerAspect playerAspect in SystemAPI.Query<PlayerAspect>().WithAll<PlayerTag>())
            {
                playerAspect.PlayerInputData.ValueRW.MovementDirection = movementDirection;
                playerAspect.PlayerInputData.ValueRW.RotationDirection = rotationDirection;
                playerAspect.PlayerInputData.ValueRW.IsShooting = isShooting;
                
                SystemAPI.SetSingleton(playerAspect.PlayerInputData.ValueRO);
            }
        }
        #endregion
    }
}