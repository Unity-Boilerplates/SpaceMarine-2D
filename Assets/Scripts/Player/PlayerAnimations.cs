using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] PlayerController playerController;
    bool jumping;

    [Header("Animator")]
    [SerializeField] Animator animator;

    public void MovementAnimationHandler(float speed) {
        if (speed <= 0.5f && speed >= -0.5f && speed != 0f) animator.speed = 0.5f;
        else animator.speed = 1f;

        animator.SetFloat("RunningSpeed", Mathf.Abs(speed));
    }

    public void JumpAnimationHandler() {
        if (!playerController.GetStatus("TouchingGround") && !jumping) {
            jumping = true;
            animator.speed = 1f;
            animator.SetBool("IsJumping", true);
        }

        if(playerController.GetStatus("TouchingGround") && jumping) {
            jumping = false;
            animator.SetBool("IsJumping", false);
        }

        if (!playerController.GetStatus("Jumping")) {
            playerController.SetStatus("Jumping", true);
            animator.SetBool("IsJumping", !playerController.GetStatus("TouchingGround"));

        }
    }


}
