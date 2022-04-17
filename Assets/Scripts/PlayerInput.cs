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


    public void MoveStick(InputAction.CallbackContext context) {
        movement.SetHorizontalMovement(context.ReadValue<Vector2>().x);

        if (context.ReadValue<Vector2>().y <= -0.5) pressingDown = true;
        else pressingDown = false;
        

    }


    private void Jump(InputAction.CallbackContext context) {
        if (context.performed && movement.GetTouchingGround()) movement.StartJump();
        if (context.canceled && movement.GetYVelocity() > 0f) movement.StopJump();
    }

    void PlatformJumpOff() {
        movement.JumpOff();
    }



}
