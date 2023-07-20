using System;
using UnityEngine;

public class Player : MonoBehaviour {
    private float horizontal;
    private Rigidbody2D rb;
    private Dust dust;
    private Vector2 spawnPoint;

    [Header("Values")]
    [SerializeField] private float jumpingPower = 8f;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float slidingSpeed;

    [Header("Ground Detection")]
    [SerializeField] private Vector2 checkSphereRadius;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask groundLayer;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        dust = GetComponentInChildren<Dust>();
        dust.Hide();
        IsFacingRight = true;
        spawnPoint = transform.position;
        GameInput.Instance.OnPlayerJump += OnJump;
    }
    private void OnDestroy() {
        GameInput.Instance.OnPlayerJump -= OnJump;
    }

    void Update() {
        Flip();
        ShowDust();
    }

    private void FixedUpdate() {
        IsGrounded = Physics2D.OverlapBox(feet.position, checkSphereRadius, 0f, groundLayer);
        HandleMovement();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "SpawnPoint") {
            spawnPoint = transform.position;
            Debug.Log(spawnPoint);
        }
        else if (other.gameObject.tag == "Killable") {
            transform.position = spawnPoint;
        }
    }

    private void HandleMovement() {
        horizontal = GameInput.Instance.GetHorizontalMovement();

        float moveDir = horizontal * moveSpeed * Time.fixedDeltaTime;
        float slidingVelocity = slidingSpeed * Time.fixedDeltaTime;

        if (GetComponent<IceSliding>().IsOnIce) {
            if (IsFacingRight) {
                rb.velocity = new Vector2(moveDir + slidingVelocity, rb.velocity.y);
            } else {
                rb.velocity = new Vector2(moveDir - slidingVelocity, rb.velocity.y);
            }
        } else {
            rb.velocity = new Vector2(moveDir, rb.velocity.y);
        }


        IsWalking = horizontal != 0f;
    }

    private void OnJump(object sender, EventArgs e) {
        if (!IsGrounded) return;

        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    private void Flip() {
        if ((IsFacingRight && horizontal < 0f) || (!IsFacingRight && horizontal > 0f)) {
            IsFacingRight = !IsFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void ShowDust() {
        if (IsWalking && IsGrounded) {
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
    public bool IsGrounded { get; private set; }
    public bool IsFacingRight { get; private set; }
}
