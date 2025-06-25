using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -15f)
            Destroy(gameObject);
    }
}
