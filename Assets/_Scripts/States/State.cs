using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour {
    [SerializeField]
    protected State JumpState, FallState;
    protected Agent agent;
    public UnityEvent onEnter, onExit;


    public void initializeState(Agent agent) {
        this.agent = agent;
    }

    public void Enter() {
        this.agent.agentInput.OnAttack += HandleAttack;
        this.agent.agentInput.OnJumpPressed += HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased += HandleJumpReleased;
        this.agent.agentInput.OnMovement += HandleMovement;
        onEnter?.Invoke();
        EnterState();
    }

    protected virtual void EnterState() {
    }

    protected virtual void HandleAttack() {
    }

    protected virtual void HandleJumpPressed() {
        TestJumpTransition();
    }

    protected virtual void HandleJumpReleased() {
    }

    protected virtual void HandleMovement(Vector2 obj) {
    }

    public virtual void StateUpdate() {
        TestFallTransition();
    }

    public virtual void StateFixedUpdate() {
    }

    public void Exit() {
        this.agent.agentInput.OnAttack -= HandleAttack;
        this.agent.agentInput.OnJumpPressed -= HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        this.agent.agentInput.OnMovement -= HandleMovement;
        onExit?.Invoke();
        ExitState();
    }

    protected virtual void ExitState() {
    }

    private void TestJumpTransition() {
        if(agent.groundDetector.isGrounded) {
            agent.TransitionToState(JumpState);
        }
    }

    protected bool TestFallTransition() {
        if(!agent.groundDetector.isGrounded) {
            agent.TransitionToState(FallState);
            return true;
        }
        return false;
    }
}
