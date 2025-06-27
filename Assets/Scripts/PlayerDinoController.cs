using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDinoController : MonoBehaviour
{
    private DinoData dinoData;
    private Rigidbody2D rb;
    private bool isGrounded = true;

    public void Setup(DinoData data)
    {
        dinoData = data;
        // Optionally set sprite here if prefab uses SpriteRenderer
        var sr = GetComponent<SpriteRenderer>();
        if (sr && dinoData.dinoSprite)
            sr.sprite = dinoData.dinoSprite;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Constant forward movement
        rb.linearVelocity = new Vector2(dinoData != null ? dinoData.speed : 5f, rb.linearVelocity.y);

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, dinoData != null ? dinoData.jumpForce : 10f);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;
        // Handle obstacle/collectible collision here
    }
} 