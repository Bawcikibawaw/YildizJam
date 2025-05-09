using Murat.Scripts.Runtime.Events;
using Murat.Scripts.Runtime.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Murat.Scripts.Runtime.Managers
{
    public class InputManager : MonoSingleton<InputManager>
    {
        private MyInputActions _myInputActions;
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _myInputActions = new MyInputActions();
            _myInputActions.Player.Enable();

            _myInputActions.Player.Movement.performed += OnMovementPerformed;
            _myInputActions.Player.Movement.canceled += OnMovementCanceled;
            
            _myInputActions.Player.Jump.started += OnJumpStarted;
            _myInputActions.Player.Jump.canceled += OnJumpCanceled;
            
            _myInputActions.Player.Dash.started += OnDashStarted;
        }

        private void OnMovementPerformed(InputAction.CallbackContext obj)
        {
            InputEvents.Instance.onMoveStart?.Invoke(obj.ReadValue<Vector2>());
        }
        
        private void OnMovementCanceled(InputAction.CallbackContext obj)
        {
            InputEvents.Instance.onMoveStop?.Invoke();
        }
        
        private void OnJumpStarted(InputAction.CallbackContext obj)
        {
            InputEvents.Instance.onJumpStart?.Invoke();
        }
        
        private void OnJumpCanceled(InputAction.CallbackContext obj)
        {
            InputEvents.Instance.onJumpCanceled?.Invoke();
        }
        
        private void OnDashStarted(InputAction.CallbackContext obj)
        {
            InputEvents.Instance.onDash?.Invoke();
        }

        private void UnSubscribeEvents()
        {
            _myInputActions.Player.Movement.performed -= OnMovementPerformed;
            _myInputActions.Player.Movement.canceled -= OnMovementCanceled;
            
            _myInputActions.Player.Jump.started -= OnJumpStarted;
            _myInputActions.Player.Dash.started -= OnDashStarted;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
        
    }
}
