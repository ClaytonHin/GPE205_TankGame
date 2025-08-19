using NUnit.Framework;
// Include the System.Collections.Generic library to access extra functionality (Specifically Lists)
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Create a static variable that can be used for objects to point to the SINGLE game manager that will exist
    public static GameManager instance;

    // Create a Lists header, so the inspector can know which type of prefab object these variables are listed within
    [Header("Lists")]
    // Create a variable to store a list of players/player controllers within the game
    public List<PlayerController> players;
    // Create a variable to store a list of Tank Pawns within the game
    public List<TankPawn> pawns;
    // Create a variable to store a list of AI Controllers within the game
    public List<AIController> aiControllers;
    // Create a variable to store a list of respawn points within the game
    private List<Transform> respawnPoints = new List<Transform>();

    // Create a Prefab header, so the inspector can know which type of prefab object these variables are listed within
    // NOTE: Prefabs are a way storing and retrieving an object with all of its components attached; Think of this like a object template
    [Header("Prefabs")]
    // Create variables to store the player pawn, and the player controller prefabs
    public GameObject playerPawnPrefab;
    public GameObject playerControllerPrefab;

    // Create a Header for our helperObjects such as the level generator
    [Header("Helper Objects")]
    // Create a LevelGenerator object, to generate levels within the game manager
    public LevelGenerator levelGenerator;


    // Awake is executed right before an object in created in the scene
    private void Awake()
    {
        // Check to ensure that this is only one Game Manager 
        if (instance == null)
        {
            // Set this instance of the Game Manager to the static instance variable
            instance = this;

            // Ensure that this object is not destroyed when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If the instance exists already, then destroy the newly created gameObject
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Generate the level
        levelGenerator.GenerateLevel();

        // Spawn the player when the script begins execution
        SpawnPlayer(Vector3.zero);
    }

    // Create a function to add the Respawn Point components to the respawn points list
    public void addRespawnPoints(RespawnPoint[] respawnPoints)
    {
        // Loop through each respawn point, and add it to the list
        foreach (RespawnPoint respawnPoint in respawnPoints)
        {
            // Add the respawn point to the list
            this.respawnPoints.Add(respawnPoint.transform);
        }
    }

    // Create a function that gets a random spawn point from the list
    public Transform GetRespawnPoint()
    {
        // Create a variable to store a random respawn point between 0 and the total
        int respawnPosition = Random.Range(0, respawnPoints.Count);
        // Return the randomized respawn position
        return respawnPoints[respawnPosition];
    }

    // Create a function that will spawn the player within the scene if a player does not already exist
    // Pass in the spawn position of the player as a parameter
    public void SpawnPlayer(Vector3 spawnPosition)
    {
        // If the players spawn position is default, then respawn them at one of the respawn points
        if (spawnPosition == Vector3.zero)
        {
            // Grab another random respawn point, and spawn the player there
            Transform randomRespawn =  GetRespawnPoint();

            // Check if there is a random respawn value
            if (randomRespawn != null)
            {
                // If there is a randomRespawn value, then set the spawn position to the randomized spawn position
                spawnPosition = randomRespawn.position;
            }
            else
            {
                // If there are no respawn points, then set the spawn position to spawn at (0,0,0)
                spawnPosition = Vector3.zero;
            }
        }

        // Instanciate/create a variable to store the player controller. 
        // Instantiate takes a type, and which variable of that type you want to instantiate
        GameObject tempPlayerControllerObject = Instantiate<GameObject>(playerControllerPrefab);
        // Set the player controller object to be placed at (0,0,0) within the scene
        tempPlayerControllerObject.transform.position = Vector3.zero;
        // Grab the player controller component and save it within a local variable
        PlayerController tempPlayerController = tempPlayerControllerObject.GetComponent<PlayerController>();
        // Instantiate/create a variable to store the player pawn
        GameObject tempPlayerPawnObject = Instantiate<GameObject>(playerPawnPrefab);
        // Get the pawn component of the player
        TankPawn tempPlayerPawn = tempPlayerPawnObject.GetComponent<TankPawn>();
        // Move the player pawn to the spawn position; This is passed in as a parameter for this function
        tempPlayerPawnObject.transform.position = spawnPosition;
        // Reattach the controller component to the Player/Tank Pawn
        tempPlayerController.pawn = tempPlayerPawn;
    }
}
