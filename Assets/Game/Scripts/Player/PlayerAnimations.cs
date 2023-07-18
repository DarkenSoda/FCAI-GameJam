using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {
    private Animator anim;
    private int currentState;
    private int previousState;

    private readonly int Idle = Animator.StringToHash("Idle");
    private readonly int Run = Animator.StringToHash("Run");
    private readonly int Jump = Animator.StringToHash("Jump");
    private readonly int Fall = Animator.StringToHash("Fall");
    private readonly int Land = Animator.StringToHash("Land");

    private float lockedTill;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        currentState = GetState();

        if(currentState == previousState) return;

        previousState = currentState;
        anim.CrossFade(currentState, 0, 0);
    }

    private int GetState() {
        if(Time.time < lockedTill) return currentState;

        Vector2 velocity = GetComponentInParent<Player>().GetVelocity();

        if(velocity.y > 0) return Jump;
        if(velocity.y < 0) return Fall;

        if(velocity.y == 0 && currentState == Fall) return LockState(Land, .2f);

        if(velocity.x != 0) return Run;

        return Idle;
    }

    private int LockState(int state, float delay) {
        lockedTill = Time.time + delay;
        return state;
    }
}
