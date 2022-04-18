using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Component Controllers")]
    [SerializeField] PlayerAnimations animations;
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerInputActions input;


    [Header ("Shotting")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shotPoint;


    [Header ("Gizmos")]
    [SerializeField] bool showShotPoints;
    Dictionary<string, bool> status;

    

    void Start() {
        status = new Dictionary<string, bool>();
        status.Add("TouchingGround", false);
        status.Add("Jumping", false);
        status.Add("Ducking", false);
        status.Add("FacingRight",true);
        status.Add("Attacking",false);


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
        if (GetStatus("TouchingGround")) {
            SetStatus("Jumping", false);
            animations.DuckingAnimationHandler();
        }
        else SetStatus("Jumping", true);

        animations.JumpAnimationHandler();
        animations.AttackAnimationHandler();
        
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

    public void Shot(){
        if(GetStatus("TouchingGround")) SetStatus("Attacking",true);
        GameObject newShot;
        newShot = Instantiate(bullet, shotPoint.position, Quaternion.identity);
        newShot.transform.parent = GameObject.Find("__Dynamic").transform; 
        
        if(GetStatus("FacingRight")) newShot.GetComponent<BulletController>().SetDirection(Vector3.right);
        if(!GetStatus("FacingRight")) newShot.GetComponent<BulletController>().SetDirection(Vector3.left);
    }

    public void EndShot(){
        SetStatus("Attacking",false);
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if(showShotPoints) Gizmos.DrawWireSphere(this.shotPoint.position, 0.1f);
    }
}
