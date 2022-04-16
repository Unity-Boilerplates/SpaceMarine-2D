using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && movement.GetOnGround()) movement.StartJump();
        if (context.canceled && movement.GetYVelocity() > 0f) movement.StopJump();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement.SetHorizontalMovement(context.ReadValue<Vector2>().x);
    }

}
