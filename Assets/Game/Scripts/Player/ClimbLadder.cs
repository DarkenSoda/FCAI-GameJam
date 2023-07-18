using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour {
    private bool inLadderRange;

    [SerializeField] private float climbingSpeed = 4f;

    [SerializeField] private GameInput gameInput;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        HandleClimbing();
    }

    private void HandleClimbing() {
        float vertical = gameInput.GetVerticalMovement();

        if (inLadderRange && Mathf.Abs(vertical) > 0f) {
            IsClimbing = true;
        }

        if (vertical < 0f && GetComponent<Player>().IsGrounded) {
            IsClimbing = false;
        }

        if (IsClimbing) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbingSpeed);
        } else {
            rb.gravityScale = 1f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Ladder>() == null) return;

        inLadderRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<Ladder>() == null) return;

        inLadderRange = false;
        IsClimbing = false;


        // Might remove this later
        // Decrease his y velocity so he doesn't fly after climbing
        // Can also set this to 0 to remove the small fly after climbing
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
    }

    public bool IsClimbing { get; private set; }
}
