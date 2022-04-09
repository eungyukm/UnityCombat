    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.Events;


    [CreateAssetMenu(fileName ="InputReader", menuName = "Input/InputReader")]
    public class InputReader : ScriptableObject, GameInput.IGamePlayActions
    {
        private GameInput _gameInput;
        
        // GamePlay
        public event UnityAction<Vector2, bool> CameraMoveEvent = delegate { };
        public event UnityAction EnableMouseControlCameraEvent = delegate { };
        public event UnityAction DisableMouseControlCameraEvent = delegate {  };
        public event UnityAction<Vector2> MoveEvent = delegate {  };

        private void OnEnable()
        {
            if(_gameInput == null)
            {
                _gameInput = new GameInput();

                _gameInput.GamePlay.SetCallbacks(this);
            }
        }

        private void OnDisable()
        {
            DisableAllInput();
        }

        public void EnableGamePlayInput()
        {
            _gameInput.GamePlay.Enable();
        }

        public void DisableAllInput()
        {
            _gameInput.GamePlay.Disable();
        }

        public void OnMouseControlCamera(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                EnableMouseControlCameraEvent.Invoke();
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                DisableMouseControlCameraEvent.Invoke();
            }
        }

        public void OnRotateCamera(InputAction.CallbackContext context)
        {
            Vector2 pos = context.ReadValue<Vector2>();
            Debug.Log("Mouse Pos X : " + pos.x + "Mouse Pos Y : " + pos.y);
            CameraMoveEvent.Invoke(pos, IsDeviceMouse(context));
        }

        private bool IsDeviceMouse(InputAction.CallbackContext context)
        {
            return context.control.device.name == "Mouse";
        }
    }
