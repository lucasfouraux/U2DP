using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State {
    public State MoveState;

    protected override void EnterState() {
        agent.animationManager.PlayAnimation(AnimationType.idle);
        print(agent.rb2d.velocity.x);
        // if(agent.groundDetector.isGrounded)
        //     agent.rb2d.velocity = Vector2.zero;
    }

    protected override void HandleMovement(Vector2 input) {
        if(Mathf.Abs(input.x) > 0) {
            agent.TransitionToState(MoveState);
        }
    }
}
