using UnityEngine;

// Modify the parent class for this specific class; Specifically to inherit the methods and properties of our controller class
public class PlayerController : Controller
{
    // Create keycodes the correlate the inputs on mouse and keyboard
    // These will be used in combination with Input.GetKey to determine which key the player is pressing, and which action that correlates to
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;

    // Start is called once before the first execution of Update after MonoBehaviour is created
    public override void Start()
    {
    }

    // Update is called once per frame
    // Use the override method to have this class constantly call the MakeDescisions loop within the parent Controller class every frame draw
    public override void Update()
    {
        // Run the MakeDescisions function to ensure that and inputs are updated per frame draw
        MakeDescisions();
    }

    // OnDestroy function is called whenever the object this component is attached to gets destroyed/removed from the scene
    public void OnDestroy()
    {
        
    }


    public override void MakeDescisions()
    {
      // Check for player inputs using a series of if statements
      //Check if the player is pressing W (Going forward)
      if (Input.GetKey(moveForwardKey))
        {
            // Call the MoveForward function within the pawn class
            pawn.MoveForward();
        }

      //Check if the player is pressing S (Going backwards)
      if (Input.GetKey(moveBackwardKey))
        {
            // Call the MoveBackward function within the pawn class
            pawn.MoveBackward();
        }

      //Check if the player is pressing D (Rotating clockwise/right)
      if (Input.GetKey(rotateClockwiseKey))
        {
            // Call the RotateClockwise function within the pawn class
            pawn.RotateClockwise();
        }    

      //Check if the player is pressing A (Rotating counterclockwise/left)
      if (Input.GetKey(rotateCounterClockwiseKey))
        {
            // Call the RotateCounterClockwise function within the pawn class
            pawn.RotateCounterClockwise();
        }
    }
}
