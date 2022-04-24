using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour{
    [Header("Controller")]
        [SerializeField] PlayerController playerController;

    [Header("Movement")]
        [SerializeField] float movementSpeed = 12f;
        [SerializeField] Transform feet;
        [SerializeField] float hitForce;

    [Header("Gravity")]
        [SerializeField] bool touchingGround = false;
        [SerializeField] float jumpForce = 20f;

    [Header("Raycast")]
        [SerializeField] float groundLength = 0.5f;
        [SerializeField] Vector3 colliderOffset;
        [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;
    float horizontalMovement;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        if(!playerController.GetStatus("Hurt")) MovePlayer();
        else knockBack();
        checkTouchingGround();
    }

    void knockBack(){
        transform.Translate(new Vector3(-1, 0f, 0f) * movementSpeed * Time.fixedDeltaTime);

    }
    public bool GetTouchingGround(){
        return touchingGround;
    }

    public Transform GetFeetPosition() {
        return feet;
    }


    public void SetHorizontalMovement(float movement){
        this.horizontalMovement = movement;
    }
    
    public float GetYVelocity() {
        return rb.velocity.y;
    }



    public void JumpOff() {
        List<RaycastHit2D> groundCasts = new List<RaycastHit2D>();

        groundCasts.Add(Physics2D.Raycast(feet.position + colliderOffset, Vector2.down, groundLength, groundLayer));
        groundCasts.Add(Physics2D.Raycast(feet.position - colliderOffset, Vector2.down, groundLength, groundLayer));

        foreach (RaycastHit2D hit in groundCasts) {
            if (hit != false && hit.collider.gameObject.tag == "Platform")
                hit.collider.gameObject.GetComponent<EffectorCheck>().RotateDown();
        }
    }


    public void StartJump(){
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void StopJump(){
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);    
    }


    void checkTouchingGround() {
        touchingGround = Physics2D.Raycast(feet.position + colliderOffset, Vector2.down, groundLength, groundLayer)
            || Physics2D.Raycast(feet.position - colliderOffset, Vector2.down, groundLength, groundLayer);
        playerController.SetStatus("TouchingGround", touchingGround);
        
    }

    void MovePlayer() {
        transform.Translate(new Vector3(horizontalMovement, 0f, 0f) * movementSpeed * Time.fixedDeltaTime);
        Flip(horizontalMovement);
    }

    void Flip(float horizontalMovement){
        if (playerController.GetStatus("FacingRight") && horizontalMovement < 0f || !playerController.GetStatus("FacingRight") && horizontalMovement > 0f){
            playerController.SetStatus("FacingRight",!playerController.GetStatus("FacingRight"));
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(feet.position + colliderOffset, feet.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(feet.position - colliderOffset, feet.position - colliderOffset + Vector3.down * groundLength);
    }



}
