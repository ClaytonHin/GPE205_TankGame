using UnityEngine;

public class TankMover : Mover
{
    // Create a private local variable to store the parents rigidbody component from its parent object (AKA the Tank's Rigidbody)
    private Rigidbody m_Rigidbody;
    // Include the tank pawn class since it is needed to access the speed variable within it
    private TankPawn tankPawn;

    // Override the start function in the mover class, and use it to only grab the Ridgidbody data once
    public override void Start()
    {
        // Grab the rigidbody component information from whatever parent this component is attached to
        m_Rigidbody = GetComponent<Rigidbody>();

        // Initialize the Tank Pawn Component information when this script is first loaded
        tankPawn = GetComponent<TankPawn>();
    }


    // Create a public function that will override and define how the move method should function for this specific class
    public override void Move(Vector3 moveVector)
    {
        // Create a new local move vector to represent where we want the pawn to move to; This will always start at 0 / Idle
        Vector3 newMoveVector = Vector3.zero;
        // Set this vector to hold both the forward direction value, along with the value from our movement vector's Z axis; Since it can only move forward and backward on the Z axis
        newMoveVector = transform.forward * moveVector.z;
        // Adjust the value of the newMoveVector to account for the speed of the object, since it will slowly ramp up in speed until it hits 1 unit per second
        newMoveVector *= tankPawn.moveSpeed;
        // Convert speed from units per frame draw into units per second, which allows for it to run based on clock timer; rather than based on your CPU processing speed
        //This is done by multiplying our vector by how long it took to draw the last frame
        newMoveVector *= Time.deltaTime;
        // Move the Rigidbody/Object in the world
        m_Rigidbody.MovePosition(m_Rigidbody.position);
    }


    // Create another public function that overrides and defines how the rotate method should function for this specific class
    public override void Rotate(Vector3 rotateVector)
    {
        // Create a local float to store the value for our rotation force; Start at zero rotation
        float rotateAmount = 0.0f;
        // Change the rotateAmount based on the rotateVector's Y value, which will be defined when this method is called
        rotateAmount = rotateVector.y;
        // Change the Y value of the vector based on the tankPawn's rotation speed
        rotateAmount *= tankPawn.rotateSpeed;
        // Update that value based on the time it took to draw the last frame. This changes this value from degrees per frame, to degrees per second 
        rotateAmount *= Time.deltaTime;
        // Update the Objects/Tanks rotation transform based on the total rotation value per second
        transform.Rotate(0, rotateAmount, 0);
    }
}
