using UnityEngine;

// Modify the parent class for this specific class; Specifically to inherit the methods and properties of our controller class
public class PlayerController : Controller
{
    // Start is called once before the first execution of Update after MonoBehaviour is created
    void Start()
    {
    }


    // Update is called once per frame
    // Use the override method to have this class constantly call the MakeDescisions loop within the parent Controller class every frame draw
    protected override void Update()
    {
        // Run the Update method specified within the parent Controller class
        base.Update();
    }


    protected override void MakeDescisions()
    {
        // This is where the player controller will make descisions based on keyboard input
        // Use Unity's build in Keyboard -> Joystick conversion controls.

        /* Create a vector3 that will store the directional value for which axis the player is moving in/towards 
        (FOR EXAMPLE: If the player is moving forward in the x direcion, the Vector 3 would be (1,0,0) ) */
        Vector3 moveVector = Vector3.zero;

        // Define the X value within the Vector3 to recieve input from any horizontal movements in a joystick fashion
        moveVector.x = Input.GetAxis("Horizontal");

        // Define the Z value within the Vector3 to recieve input from any forwards/backwards movements in a joystick fashion
        moveVector.z = Input.GetAxis("Vertical");

        // Call the Move/MakeDescisions method, and only allow it to move in the Z axis
        pawn.Move(new Vector3(0, 0, moveVector.z));

        // Call the Rotate method, and only allow for roatation around the y axis
        pawn.Rotate(new Vector3(0, moveVector.x, 0));

        // This tells this method to run specifically the parents definition of MakeDescisions, instead of overriding/modifying it
        base.MakeDescisions();
    }
}
