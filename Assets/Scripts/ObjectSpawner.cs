using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Create a variable to store the GameObject that will be spawned
    public GameObject objectToSpawn;
    // Create a variable to store the initial spawn delay
    public float firstSpawnDelay;
    // Create a variable to store the amount of time before an object is respawned
    public float respawnTime;
    // Create a variable to store the time until the next spawn happens
    private float nextSpawnTime;
    // Create a variable to store the object that has most recently been spawned
    private GameObject spawnedObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the time until the first spawn happens
        nextSpawnTime = Time.time + firstSpawnDelay;

    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if we need to spawn an object
        CheckForSpawn();

    }

    // Create a function that will check if we need to spawn an object based on the spawn time
    public void CheckForSpawn()
    {
        // Check to see if there is already an object spawned, to ensure we don't overspawn pickups
        if (spawnedObject == null)
        {
            // Check to see if we have exceeded our nextSpawnTime
            if (Time.time > nextSpawnTime)
            {
                // Instantiate the game object 
                // This uses "as GameObject" as a form of typecasting this object. If the typecase is successful, then it returns as a GameObject; Otherwise it returns null
                spawnedObject = Instantiate<GameObject>(objectToSpawn, transform.position, transform.rotation) as GameObject;
                // Reset the nextSpawnTime
                nextSpawnTime = Time.time + respawnTime;
            }
        }
        else
        {
            // Reset the nextSpawnTime
            nextSpawnTime = Time.time + respawnTime;
        }
    }
}
