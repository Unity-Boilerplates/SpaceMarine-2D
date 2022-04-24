using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [Header("Controller")]
        [SerializeField] PlayerController playerController;

    [Header("Animator")]
        [SerializeField] Animator animator;
        [SerializeField] AnimationClip hitAnimation;

    void Update(){
        
    }

    public void MovementAnimationHandler(float speed) {
        if (speed <= 0.5f && speed >= -0.5f && speed != 0f) animator.speed = 0.5f;
        else animator.speed = 1f;
        animator.SetFloat("RunningSpeed", Mathf.Abs(speed));
    }

    public void JumpAnimationHandler() {
        animator.speed = 1f;

        if (!playerController.GetStatus("TouchingGround")) animator.SetBool("IsJumping", true);
        if(playerController.GetStatus("TouchingGround")) animator.SetBool("IsJumping", false);

    }

    public void DuckingAnimationHandler() {
        animator.SetBool("IsDucking", !playerController.GetStatus("Ducking"));
    }

    public void AttackAnimationHandler(){
        if(playerController.GetStatus("TouchingGround")) animator.SetBool("IsAttacking", playerController.GetStatus("Attacking"));
    }

    public void HurtAnimationHandler(){
        animator.SetTrigger("Hurt");
    }

}
