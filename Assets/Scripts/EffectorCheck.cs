using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorCheck : MonoBehaviour {
    private PlatformEffector2D effector;
    [SerializeField] float waitTime = 0f;
    public bool jumpingOff = false;
    void Start() {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update() {
        if (waitTime <= 0f && effector.rotationalOffset == 180f)
            effector.rotationalOffset = 0f;
        else
            waitTime -= Time.deltaTime;
    }
    public void RotateDown() {
        effector.rotationalOffset = 180f;
        waitTime = 0.5f;

    }



}
