using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Component Controllers")]
    [SerializeField] PlayerAnimations animations;
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerInputActions input;

    [SerializeField] Dictionary<string, bool> status;

    [SerializeField] bool jumpingState;
    [SerializeField] bool idleState;
    [SerializeField] bool runningState;
    [SerializeField] bool shootingState;

    void Start() {
        status = new Dictionary<string, bool>();
        status.Add("TouchingGround", false);
        status.Add("Jumping", false);
        status.Add("Running", false);

    }

    public bool GetStatus(string name) {
        return status[name];
    }

    public Dictionary<string, bool> GetAllStatus() {
        return status;
    }

    public void SetStatus(string name,bool value) {
        status[name] = value;

    }


    void FixedUpdate() {
        TouchingGroundActions();
    }


    void TouchingGroundActions() {
        if (GetStatus("TouchingGround")) SetStatus("Jumping", false);
        else SetStatus("Jumping", true);

        animations.JumpAnimationHandler();
    }
    public void MovePlayer(float horizontalMovement) {
        movement.SetHorizontalMovement(horizontalMovement);
        animations.MovementAnimationHandler(horizontalMovement);
    }


    
    public void JumpOffPlayer() {
        movement.JumpOff();
    }

    public void Jump() {
        if (movement.GetTouchingGround()) {
            movement.StartJump();
        }
        
    }

    public void StopJump() {
        if (movement.GetYVelocity() > 0f) movement.StopJump();
    }

    public Transform GetFeetPosition() {
        return movement.GetFeetPosition();
    }

}
