using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform SpawnPoint;
    public float spawnInterval;

    private float spawnBuffer;

    // Update is called once per frame
    void Update()
    {
        if(spawnBuffer <= 0)
        {
            int rand = Random.Range(0, objectsToSpawn.Length);
            Instantiate(objectsToSpawn[rand], SpawnPoint.position, Quaternion.identity);
            spawnBuffer = spawnInterval;
        }
        else
        {
            spawnBuffer -= Time.deltaTime;
        }
    }
}
