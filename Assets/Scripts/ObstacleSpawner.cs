using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2.5f;
    public float spawnDistance = 22f;
    public float minY = -1f, maxY = 1.5f;
    private float timer = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null)
        {
            var playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                return; // Wait until player exists
        }
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Vector3 spawnPos = player.position + Vector3.right * spawnDistance;
            spawnPos.y = Random.Range(minY, maxY);
            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
