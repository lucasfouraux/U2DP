using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public PlayerInput playerInput;

    void Awake() {
        playerInput = GetComponentInParent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start() {
        playerInput.OnMovement += HandleMovement;
    }

    private void HandleMovement(Vector2 input) {
        if(Mathf.Abs(input.x) > 0) {
            rb2d.velocity = new Vector2(input.x * 5, rb2d.velocity.y);
        } else {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }
}
