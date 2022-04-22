using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public void TriggerExplosion(){
        animator.SetTrigger("Explode");
    }

}
