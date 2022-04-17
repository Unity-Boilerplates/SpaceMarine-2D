using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour{
    
    [Header("Movement")]
    [SerializeField] float movementSpeed = 12f;
    bool isFacingRight = true;
    float horizontalMovement;

    [Header("Gravity")]
    [SerializeField] bool touchingGround = false;
    [SerializeField] float jumpForce = 20f;
    Rigidbody2D rb;


    [Header("Raycast")]
    [SerializeField] float groundLength = 0.5f;
    [SerializeField] Vector3 colliderOffset;
    [SerializeField] LayerMask groundLayer;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        MovePlayer();
        checkTouchingGround();
    }


    public bool GetTouchingGround(){
        return touchingGround;
    }

    public Vector3 GetColliderOffset() {
        return colliderOffset;
    }

    public float GetGroundLength() {
        return groundLength;
    }

    public void SetHorizontalMovement(float movement){
        this.horizontalMovement = movement;
    }
    
    public float GetYVelocity() {
        return rb.velocity.y;
    }



    public void JumpOff() {
        List<RaycastHit2D> groundCasts = new List<RaycastHit2D>();

        groundCasts.Add(Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer));
        groundCasts.Add(Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer));

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
        touchingGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer)
            || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
    }

    void MovePlayer() {
        transform.Translate(new Vector3(horizontalMovement, 0f, 0f) * movementSpeed * Time.deltaTime);
        Flip(horizontalMovement);
    }

    void Flip(float horizontalMovement){
        if (isFacingRight && horizontalMovement < 0f || !isFacingRight && horizontalMovement > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
