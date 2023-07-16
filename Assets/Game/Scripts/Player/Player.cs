using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    private Rigidbody2D rb;

    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = gameInput.GetMovement();
        Flip();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
