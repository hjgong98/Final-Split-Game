using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public GameObject MetalObstacle;
    public Transform SpawnPoint;
    public float spawnInterval;

    private int objectSpawnCounterForObstacle;
    private float spawnBuffer;

    // Update is called once per frame
    void Update()
    {
        if(spawnBuffer <= 0)
        {
            int objectRandomIdx = Random.Range(0, objectsToSpawn.Length);
            int obstacleSpawnLimit = Random.Range(1, 3);

            if (obstacleSpawnLimit == 2) {
                if (objectSpawnCounterForObstacle > 6) {
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
