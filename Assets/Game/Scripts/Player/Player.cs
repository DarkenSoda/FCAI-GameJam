using System;
using UnityEngine;

public class Player : MonoBehaviour {
    private float horizontal;
    private bool isFacingRight = true;
    private bool isGrounded = true;
    private Rigidbody2D rb;
    private Dust dust;

    [Header("Values")]
    [SerializeField] private float jumpingPower = 8f;
    [SerializeField] private float speed = 4f;

    [Header("Ground Detection")]
    [SerializeField] private Vector2 checkSphereRadius;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;

    [Header("Input")]
    [SerializeField] private GameInput gameInput;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        dust = GetComponentInChildren<Dust>();
        dust.Hide();

        gameInput.OnPlayerJump += OnJump;
    }

    void Update() {
        Flip();
        ShowDust();
        HandleMovement();
        IsWalking = horizontal != 0f;
    }

    private void FixedUpdate() {
        isGrounded = Physics2D.OverlapBox(feet.position, checkSphereRadius, 0f, groundLayer);
    }

    private void HandleMovement() {
        horizontal = gameInput.GetMovement();
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void OnJump(object sender, EventArgs e) {
        if (!isGrounded) return;

        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    private void Flip() {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f)) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void ShowDust() {
        if (IsWalking && isGrounded) {
            dust.Show();
        } else {
            dust.Hide();
        }
    }

    public Vector2 GetVelocity() {
        return rb.velocity;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(feet.position, checkSphereRadius);
    }

    public bool IsWalking { get; private set; }
}
