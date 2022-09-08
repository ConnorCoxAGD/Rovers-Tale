using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputInterpreter : MonoBehaviour, RoverInputActions.IRoverControlsActions
{
    public Vector2 m_movement;

    RoverInputActions _controls;

    private void OnEnable() {
        _controls = new RoverInputActions();
        _controls.RoverControls.SetCallbacks(this);
        _controls.Enable();
    }

    private void OnDisable() {
        _controls.Disable();
    }
    public void OnMovement(InputAction.CallbackContext value)
    {
        m_movement = value.ReadValue<Vector2>();
    }
}
