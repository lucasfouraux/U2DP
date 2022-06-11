using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
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
    }

    protected virtual void HandleJumpReleased() {
    }

    protected virtual void HandleMovement(Vector2 obj) {
    }

    public virtual void stateUpdate() {
    }

    public virtual void stateFixedUpdate() {
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
}
