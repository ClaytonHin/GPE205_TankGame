using NUnit.Framework;
// Include the System.Collections.Generic library to access extra functionality (Specifically Lists)
using System.Collections.Generic;
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

    // Create a Prefab header, so the inspector can know which type of prefab object these variables are listed within
    // NOTE: Prefabs are a way storing and retrieving an object with all of its components attached; Think of this like a object template
    [Header("Prefabs")]
    // Create variables to store the player pawn, and the player controller prefabs
    public GameObject playerPawnPrefab;
    public GameObject playerControllerPrefab;


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
        // Spawn the player when the script begins execution
        SpawnPlayer(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Create a function that will spawn the player within the scene if a player does not already exist
    // Pass in the spawn position of the player as a parameter
    void SpawnPlayer(Vector3 spawnPosition)
    {
        // Instanciate/create a variable to store the player controller. 
        // Instantiate takes a type, and which variable of that type you want to instantiate
        GameObject tempPlayerControllerObject = Instantiate<GameObject>(playerControllerPrefab);
        // Set the player controller object to be placed at (0,0,0) within the scene
        tempPlayerControllerObject.transform.position = Vector3.zero;
        // Grab the player controller component and save it within a local variable
        PlayerController tempPlayerController = tempPlayerControllerObject.GetComponent<PlayerController>();
        // Add the player to our list of players, based on the number of controller objects
        // EDIT: This is better suited if it was added to the list whenever a controller was created (MOVED TO PLAYERCONTROLLER)
        //players.Add(tempPlayerController);

        // Instantiate/create a variable to store the player pawn
        GameObject tempPlayerPawnObject = Instantiate<GameObject>(playerPawnPrefab);
        // Get the pawn component of the player
        TankPawn tempPlayerPawn = tempPlayerPawnObject.GetComponent<TankPawn>();
        // Move the player pawn to the spawn position; This is passed in as a parameter for this function
        tempPlayerPawnObject.transform.position = spawnPosition;

        // Reattach the controller component to the Player/Tank Pawn
        tempPlayerController.pawn = tempPlayerPawn;
        // Add the created pawn into our list of pawns
        // EDIT: This is better suited if it was added to the list whenever a pawn was created (MOVED TO TANKPAWN)
        //pawns.Add(tempPlayerPawn);
    }
}
