using UnityEngine;
public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public static int numberOfCoins = 10;
    public int numberOfObstacles = 10;
    public GameObject obstaclePrefab;
    public GameObject spawnAreaPlane;
    public float bufferRadius = 1.0f;
    public float coinHeight = 0f;

    private void Start()
    {
        if (spawnAreaPlane == null)
        {
            Debug.LogError("Spawn Area Plane not assigned in CoinSpawner!");
            return;
        }

        SpawnCoins();
        SpawnObstacles();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            Vector3 randomSpawnPos = GetRandomSpawnPosition();
            Instantiate(coinPrefab, randomSpawnPos, Quaternion.identity);
        }
    }
    private void SpawnObstacles()
    {
        for (int i = 0; i < numberOfObstacles; i++)
        {
            Vector3 randomSpawnPos = GetRandomSpawnPosition();
            Instantiate(obstaclePrefab, randomSpawnPos, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Renderer planeRenderer = spawnAreaPlane.GetComponent<Renderer>();
        if (planeRenderer == null)
        {
            Debug.LogError("Spawn Area Plane does not have a renderer component!");
            return Vector3.zero;
        }

        Bounds bounds = planeRenderer.bounds;

        Vector3 spawnPosition = new Vector3
            (
             Random.Range(bounds.min.x, bounds.max.x),
             coinHeight,
             Random.Range(bounds.min.z, bounds.max.z)
            );

        RaycastHit hit;
        Ray ray = new Ray(spawnPosition + Vector3.up * 100f, Vector3.down);

        if (Physics.Raycast(ray, out hit, 200f, LayerMask.GetMask("Ground")))
        {
            spawnPosition = hit.point;
        }

        return spawnPosition;
    }
}