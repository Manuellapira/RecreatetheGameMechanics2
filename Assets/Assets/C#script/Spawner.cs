using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject collectiblePrefab;   // Collectible prefab
    public GameObject obstaclePrefab;      // Obstacle prefab

    public float spawnInterval = 2f;       // Time interval between spawns
    public Vector2 spawnRangeY = new Vector2(-4f, 4f);  // Vertical spawn range for randomness

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // Increment the time since the last spawn
        timeSinceLastSpawn += Time.deltaTime;

        // Check if it's time to spawn a new object
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnObject()
    {
        // Randomly decide whether to spawn a collectible or obstacle
        GameObject objectToSpawn = Random.Range(0, 2) == 0 ? collectiblePrefab : obstaclePrefab;

        // Randomly choose a Y position within the spawn range
        float spawnY = Random.Range(spawnRangeY.x, spawnRangeY.y);

        // Set the spawn position (X is fixed off-screen, Y is random)
        Vector2 spawnPosition = new Vector2(10f, spawnY); // X=10 assumes objects move left

        // Spawn the object
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
