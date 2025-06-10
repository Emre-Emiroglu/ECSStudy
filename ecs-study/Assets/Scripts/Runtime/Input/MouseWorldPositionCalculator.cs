using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Input
{
    public sealed class MouseWorldPositionCalculator : MonoBehaviour
    {
        #region Fields
        [Header("Mouse World Position Calculator Fields")]
        [SerializeField] private Camera mainCamera;
        [SerializeField] private InputActionReference mousePositionAction;
        #endregion

        #region Properities
        public static float3 MouseWorldPosition { get; private set; }
        #endregion

        #region Executes
        private void ProcessMouseInput()
        {
            Vector2 mouseScreenPosition = mousePositionAction.action.ReadValue<Vector2>();
            
            mouseScreenPosition.y = Mathf.Clamp(mouseScreenPosition.y, 0, Screen.height);
            mouseScreenPosition.x = Mathf.Clamp(mouseScreenPosition.x, 0, Screen.width);

            Vector3 screenPoint = new Vector3(mouseScreenPosition.x, mouseScreenPosition.y,
                Mathf.Abs(mainCamera.transform.position.y));
            
            MouseWorldPosition = mainCamera.ScreenToWorldPoint(screenPoint);
        }
        #endregion

        #region Ticks
        private void Update() => ProcessMouseInput();
        #endregion
    }
}