using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    bool pressingDown = false;

    public void JumpPress(InputAction.CallbackContext context){
        if (!pressingDown) Jump(context);
        else PlatformJumpOff();
    }


    public void DownPress(InputAction.CallbackContext context) {
        if (context.performed) pressingDown = true;
        if (context.canceled) pressingDown = false;
    }

    public void MoveStick(InputAction.CallbackContext context) {
        movement.SetHorizontalMovement(context.ReadValue<Vector2>().x);
    }


    private void Jump(InputAction.CallbackContext context) {
        if (context.performed && movement.GetOnGround()) movement.StartJump();
        if (context.canceled && movement.GetYVelocity() > 0f) movement.StopJump();
    }

    void PlatformJumpOff() {
        movement.JumpOff();
    }



}
