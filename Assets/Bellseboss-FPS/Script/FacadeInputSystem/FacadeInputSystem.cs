using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class FacadeInputSystem : MonoBehaviour
{
    public event Action<Vector2> OnMove;
    public event Action<Vector2> OnLook;

    public void OnMovePlayer(InputAction.CallbackContext value)
    {
        var readValue = value.ReadValue<Vector2>();
        OnMove?.Invoke(readValue);
    }

    public void OnLookPlayer(InputAction.CallbackContext value)
    {
        var readValue = value.ReadValue<Vector2>();
        OnLook?.Invoke(readValue);
    }

    public void FirePlayer(InputAction.CallbackContext value)
    {
        Debug.Log(value.started);
    }
}