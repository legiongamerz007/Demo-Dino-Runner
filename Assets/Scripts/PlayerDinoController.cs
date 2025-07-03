using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDinoController : MonoBehaviour
{
    private DinoData dinoData;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private int lives = 3;
    private Vector3 respawnPosition;

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

    void Start()
    {
        respawnPosition = transform.position;
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Increase score and destroy collectible
            var scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(10); // +10 per coin
            }
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            lives--;
            if (lives > 0)
            {
                // Respawn at last position
                transform.position = respawnPosition;
                rb.velocity = Vector2.zero;
            }
            else
            {
                // End game
                var gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.EndGame(false);
                }
                gameObject.SetActive(false);
            }
        }
    }
} 