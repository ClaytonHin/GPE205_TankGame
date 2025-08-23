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

    // Create a header to store the states that will happen during gameplay for UI elements
    [Header("Gameplay State Objects")]
    // Create a variable to store the start state of the game (UI)
    public GameObject pressStartStateObject;
    // Create a variable to store the game state when the game is in the main menu (UI)
    public GameObject mainMenuStateObject;
    // Create a variable to store the game state when it is being played (UI)
    public GameObject playGameStateObject;
    // Create a variable to store what happens when the game is won (UI)
    public GameObject gameOverVictoryStateObject;
    // Create a variable to store what happens when the game is lost (UI)
    public GameObject gameOverFailureStateObject;
    // Create a variable to store the game options menus
    public GameObject gameOptionsStateObject;
    // Create a variable to store the credits menu
    public GameObject creditsStateObject;

    [Header("Gameplay Settings")]
    // Create a variable to store whether or not the game is in split screen mode
    public bool isSplitScreen = false;

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
        // Start the game in the beginning press start state
        ChangeGameplayState(pressStartStateObject);
    }

    // Create a function that will change the game state depending on the state of the game
    private void ChangeGameplayState(GameObject gameplayStateObject)
    {
        // Deactivate all of the game states
        DeactivateAllStates();
        // Move into the new game state/ Activate the desired game state
        gameplayStateObject.SetActive(true);

    }

    // Create a function that will deactivate all of the game states
    private void DeactivateAllStates()
    {
        // Set all of the game state objects to be inactive
        pressStartStateObject.SetActive(false);
        playGameStateObject.SetActive(false);
        mainMenuStateObject.SetActive(false);
        gameOverVictoryStateObject.SetActive(false);
        gameOverFailureStateObject.SetActive(false);
        gameOptionsStateObject.SetActive(false);
        creditsStateObject.SetActive(false);
    }

    // Create a function that will transition the game state into the main menu 
    public void ActivateMainMenu()
    {
        // Change into the main menu gameplay state
        ChangeGameplayState(mainMenuStateObject);
    }

    // Create a function that will transition the game state into the options menu 
    public void ActivateOptionsMenu()
    {
        // TODO: There are no options to change, so just leave this commented out for now. Add options later
        ChangeGameplayState(gameOptionsStateObject);
    }

    // Create a function that will transition the game state into the credits menu
    public void ActivateCreditsMenu()
    {
        // TODO: ADD A CREDITS MENU OBJECT LATER
        ChangeGameplayState(creditsStateObject);
    }

    // Create a function that will transition the game state into the play game state
    public void ActivateGameplay()
    {
        // Activate the Gameplay state
        ChangeGameplayState(playGameStateObject);

        // Start the game, and set or reset values for score, lives, etc.
        ResetPlayerScore();

        // Generate the level
        levelGenerator.GenerateLevel();

        // Check if we are in singleplayer mode
        if (!isSplitScreen)
        {
            // Spawn the player
            SpawnPlayer(Vector3.zero);

            // Set the players camera to be the correct viewport rect
            Rect viewport = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
            // Assign the created viewport to the player's camera
            players[0].playerCamera.rect = viewport;
        }
        else
        {
            // Spawn the first player
            SpawnPlayer(Vector3.zero);

            // Spawn a second player
            SpawnPlayer(new Vector3(10, 0, 10));

            // Set the players camera to be the correct viewport rect
            Rect viewport = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
            // Assign the created viewport to the player's camera
            players[0].playerCamera.rect = viewport;
            // Create the viewport for the second player
            viewport = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
            // Set player 2's camera to be the correct viewport rect
            players[1].playerCamera.rect = viewport;
        }
    }

    // Create a function that will transition the game state into the victory menu
    public void ActivateVictoryMenu()
    {
        ChangeGameplayState(gameOverVictoryStateObject);
    }

    //
    public void ActivateDefeatMenu()
    {
        ChangeGameplayState(gameOverFailureStateObject);
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

    // Create a function to reset the player scores
    public void ResetPlayerScore()
    {
        // Loop through each player in the players list
        foreach (PlayerController player in players)
        {
            // Reset the player's score to 0
            player.playerScore = 0;
        }
    }

    // Create a helper function to activate when the game is over
    public void PlayerLost(PlayerController player)
    {
        // If the player has no more lives left
        if (player.lives <= 0)
        {
            // Activate the defeat menu
            ActivateDefeatMenu();
        }
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
        // Reattach the controller component to the Player/Tank Pawn (This also sets the camera)
        tempPlayerController.Possess(tempPlayerPawn);
        // Set the pawns controller to the player controller
        tempPlayerPawn.controller = tempPlayerController;
    }
}
