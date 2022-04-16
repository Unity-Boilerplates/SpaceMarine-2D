using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGizmos : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + movement.GetColliderOffset(), transform.position + movement.GetColliderOffset() + Vector3.down * movement.GetGroundLength());
        Gizmos.DrawLine(transform.position - movement.GetColliderOffset(), transform.position - movement.GetColliderOffset() + Vector3.down * movement.GetGroundLength()); ; ;

    }

}
