using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public float scrollSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x < -20)
            transform.position += new Vector3(40, 0, 0);
    }
}
