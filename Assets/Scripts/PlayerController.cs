using UnityEngine;
// Include the System.Collections.Generic library to access extra functionality
using System.Collections.Generic;

// Modify the parent class for this specific class; Specifically to inherit the methods and properties of our controller class
public class PlayerController : Controller
{
    [Header("Input Keys")]
    // Create keycodes the correlate the inputs on mouse and keyboard
    // These will be used in combination with Input.GetKey to determine which key the player is pressing, and which action that correlates to
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey = KeyCode.Mouse2;

    [Header("Camera Data")]
    // Create a variable to store the offset of the camera from the player pawn
    [Tooltip("Local Space Vector3 Coordiantes")]public Vector3 cameraOffset;
    //Create a variable to store the aim offset of the camera in relation to the player pawn
    [Tooltip("Local Space Vector 3 Coordinates")]public Vector3 cameraAimOffset;
    // Create a variable to store the player's camera
    public Camera playerCamera;

    // Awake is run when the object is first created
    public override void Awake()
    {
    }

    // Start is called once before the first execution of Update after MonoBehaviour is created
    public override void Start()
    {
        // Add our player controller to our list of players within the GameManager Object
        GameManager.instance.players.Add(this);
        // Change our objects name, to better differentiate between multiple objects within one scene; 
        gameObject.name = "Player " + GameManager.instance.players.Count;
    }

    // Update is called once per frame
    // Use the override method to have this class constantly call the MakeDescisions loop within the parent Controller class every frame draw
    public override void Update()
    {
        // Run the MakeDescisions function to ensure that and inputs are updated per frame draw
        MakeDescisions();
    }

    // OnDestroy runs whenever the object is removed/deleted from the scene
    public void OnDestroy()
    {
        // Remove our controller object from the GameManager list, whenever it is destroyed/removed
        GameManager.instance.players.Remove(this);
    }

    // Create a function to possess a pawn with the camera
    public void Possess(Pawn pawnToPossess)
    {
        // Possess the pawn
        pawn = pawnToPossess;

        // Check if the player camera exists
        if (playerCamera != null)
        {
            // Attach the camera to the player pawn
            // Take the passed in camera aim offset, and tranform it into world space 
            Vector3 cameraWorldOffset = pawn.transform.TransformDirection(cameraOffset);
            // Move the camera to be positioned above the player pawns position
            playerCamera.transform.position = pawn.transform.position + cameraWorldOffset;
            // Take the passed in camera aim offset, and tranform it into world space 
            Vector3 playerWorldAimOffset = pawn.transform.TransformDirection(cameraAimOffset);
            // Force the camera to look at the player's aim offset in the direction the player is facing
            playerCamera.transform.LookAt(pawn.transform.position + playerWorldAimOffset);
            // Attach the camera to the player pawn, so it will follow the player
            playerCamera.transform.parent = pawn.transform;
        }
    }

    public override void MakeDescisions()
    {
      // Check for player inputs using a series of if statements
      // Check if the player is pressing W (Going forward)
      if (Input.GetKey(moveForwardKey))
        {
            // Call the MoveForward function within the pawn class
            pawn.MoveForward();
        }

      // Check if the player is pressing S (Going backwards)
      if (Input.GetKey(moveBackwardKey))
        {
            // Call the MoveBackward function within the pawn class
            pawn.MoveBackward();
        }

      // Check if the player is pressing D (Rotating clockwise/right)
      if (Input.GetKey(rotateClockwiseKey))
        {
            // Call the RotateClockwise function within the pawn class
            pawn.RotateClockwise();
        }    

      // Check if the player is pressing A (Rotating counterclockwise/left)
      if (Input.GetKey(rotateCounterClockwiseKey))
        {
            // Call the RotateCounterClockwise function within the pawn class
            pawn.RotateCounterClockwise();
        }
      // Check if the player is pressing the Left Mouse Button (Shoot)
      if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }
    }
}
