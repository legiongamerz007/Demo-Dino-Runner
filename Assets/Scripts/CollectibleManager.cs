using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public float spawnInterval = 2f;
    public float spawnDistance = 20f;
    public float minY = -1f, maxY = 2f;
    private float timer = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Vector3 spawnPos = player.position + Vector3.right * spawnDistance;
            spawnPos.y = Random.Range(minY, maxY);
            Instantiate(collectiblePrefab, spawnPos, Quaternion.identity);
        }
    }
} 