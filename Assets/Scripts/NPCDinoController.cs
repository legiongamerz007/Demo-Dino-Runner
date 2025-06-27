using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NPCDinoController : MonoBehaviour
{
    public DinoData dinoData;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private float jumpCooldown = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Constant forward movement
        rb.linearVelocity = new Vector2(dinoData != null ? dinoData.speed : 4.5f, rb.linearVelocity.y);

        // Simple AI: jump at random intervals
        if (isGrounded && jumpCooldown <= 0f)
        {
            if (Random.value < 0.01f) // 1% chance per frame
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, dinoData != null ? dinoData.jumpForce : 9f);
                isGrounded = false;
                jumpCooldown = 1.0f;
            }
        }
        if (jumpCooldown > 0f)
            jumpCooldown -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;
    }
} 