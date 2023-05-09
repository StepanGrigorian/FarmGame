using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public CustomInput Input;
    public Vector2 Axis { get; private set; }

    private void Awake()
    {
        Input = new CustomInput();
    }
    private void OnEnable()
    {
        Input.Enable();
        Input.Camera.Movement.performed += OnMovementPerformed;
        Input.Camera.Movement.canceled += OnMovementCancelled;
    }
    private void OnDisable()
    {
        Input.Disable();
        Input.Camera.Movement.performed -= OnMovementPerformed;
        Input.Camera.Movement.canceled -= OnMovementCancelled;
    }
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        Axis = value.ReadValue<Vector2>();
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        Axis = Vector2.zero;
    }
}