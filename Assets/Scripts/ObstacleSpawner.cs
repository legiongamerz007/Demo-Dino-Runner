using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            Instantiate(obstaclePrefab, new Vector3(10, -2.5f, 0), Quaternion.identity);
            timer = 0f;
        }
    }
}
