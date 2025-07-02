using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public float scrollSpeed = 5f;
    private float groundWidth;

    void Start()
    {
        // Calculate the width of the ground segment
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            groundWidth = sr.bounds.size.x;
        else
            groundWidth = 20f; // fallback value
    }

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // If this segment is off-screen to the left, move it to the right
        if (transform.position.x < -groundWidth)
        {
            float rightMost = FindRightMostGroundX();
            transform.position = new Vector3(rightMost + groundWidth, transform.position.y, transform.position.z);
        }
    }

    float FindRightMostGroundX()
    {
        float rightMost = transform.position.x;
        foreach (var ground in GameObject.FindGameObjectsWithTag("Ground"))
        {
            if (ground != this.gameObject)
            {
                float x = ground.transform.position.x;
                if (x > rightMost)
                    rightMost = x;
            }
        }
        return rightMost;
    }
}
