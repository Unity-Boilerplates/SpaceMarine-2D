using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputActions : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] PlayerController playerController;

    
    bool pressingDown = false;

    public void JumpPress(InputAction.CallbackContext context){
        if (!pressingDown) Jump(context);
        else PlatformJumpOff();
    }


    public void MoveStick(InputAction.CallbackContext context) {
        if (context.ReadValue<Vector2>().y == -1f && context.ReadValue<Vector2>().x == 0  ) pressingDown = true;
        else pressingDown = false;


        if (!pressingDown) playerController.MovePlayer(context.ReadValue<Vector2>().x);
        playerController.SetStatus("Ducking", !pressingDown);
    }

    public void ShotPress(InputAction.CallbackContext context){
        if(context.performed) playerController.Shot();
    }

    private void Jump(InputAction.CallbackContext context) {
        if (context.performed) playerController.Jump();
        if (context.canceled) playerController.StopJump();
    }

    void PlatformJumpOff() {
        playerController.JumpOffPlayer();
    }



}
