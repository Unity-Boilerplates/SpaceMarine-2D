using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGizmos : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(movement.GetFeetPosition().position + movement.GetColliderOffset(), movement.GetFeetPosition().position + movement.GetColliderOffset() + Vector3.down * movement.GetGroundLength());
        Gizmos.DrawLine(movement.GetFeetPosition().position - movement.GetColliderOffset(), movement.GetFeetPosition().position - movement.GetColliderOffset() + Vector3.down * movement.GetGroundLength());
    }

}
