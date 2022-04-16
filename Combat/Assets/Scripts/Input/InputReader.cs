using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input/InputReader")]
public class InputReader : ScriptableObject, GameInput.IGamePlayActions
{
    private GameInput _gameInput;

    // GamePlay
    public event UnityAction<Vector2, bool> CameraMoveEvent = delegate { };
    public event UnityAction EnableMouseControlCameraEvent = delegate { };
    public event UnityAction DisableMouseControlCameraEvent = delegate { };
    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction OnAttackEvent = delegate {  };

    private void OnEnable()
    {
        if (_gameInput == null)
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
        Debug.Log("Mouse Control Call!!");
        if (context.phase == InputActionPhase.Performed)
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
        var pos = context.ReadValue<Vector2>();
        // Debug.Log("Mouse Pos X : " + pos.x + "Mouse Pos Y : " + pos.y);
        CameraMoveEvent.Invoke(pos, IsDeviceMouse(context));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var moveVector = context.ReadValue<Vector2>();
        // Debug.Log("moveVector : " + moveVector);
        MoveEvent(moveVector);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            OnAttackEvent.Invoke();
        }
    }

    private bool IsDeviceMouse(InputAction.CallbackContext context)
    {
        return context.control.device.name == "Mouse";
    }
}