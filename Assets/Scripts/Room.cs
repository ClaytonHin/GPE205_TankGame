using UnityEngine;

public class Room : MonoBehaviour
{
    // Store the walls/doors in their own variable so they are easily accessible within the level generator
    public GameObject doorNorth;
    public GameObject doorSouth;
    public GameObject doorEast;
    public GameObject doorWest;
    public GameObject playerSpawn;

    // If there is a need for waypoints in a room or any extra info about the room, make sure to store it here
}
