using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public GameObject MetalObstacle;
    public Transform SpawnPoint;
    public float spawnInterval;

    private int objectSpawnCounterForObstacle;
    private float spawnBuffer;

    public GameObject bomb;

    // Update is called once per frame
    void Update()
    {
        if(spawnBuffer <= 0)
        {
            int objectRandomIdx = Random.Range(0, objectsToSpawn.Length);
            int obstacleSpawnLimit = Random.Range(1, 3);

            if (obstacleSpawnLimit == 2) {
                if (objectSpawnCounterForObstacle > 6) {
                    bool spawnBomb = Random.Range(0, 2) == 0; // 50/50 bomb or metal obstacle
                    if (spawnBomb) {
                        Debug.Log("Spawning bomb: " + bomb);
                        Instantiate(bomb, SpawnPoint.position, Quaternion.identity);
                    } else
                        Instantiate(MetalObstacle, SpawnPoint.position, Quaternion.identity);
                    objectSpawnCounterForObstacle = 0;
                } else {
                    SpawnObject(objectRandomIdx);
                }
            } else {
                SpawnObject(objectRandomIdx);
            }

            spawnBuffer = spawnInterval;
        }
        else
        {
            spawnBuffer -= Time.deltaTime;
        }
    }

    private void SpawnObject(int index) {
        Instantiate(objectsToSpawn[index], SpawnPoint.position, Quaternion.identity);
        ++objectSpawnCounterForObstacle;
    }
}
