using UnityEngine;

public class TankPawn : Pawn
{
    // Create and define our overload functions
    public override void Start()
    {
        //Get the mover component for the object this component is attached to / the tank
        mover = GetComponent<Mover>();
    }
    public override void Update()
    {
    }

    // Override and define the MoveForward function
    public override void MoveForward()
    {
        // Call the MoveForward function within the mover class
        mover.MoveForward(moveSpeed);
    }

    // Override and define the MoveBackward function
    public override void MoveBackward()
    {
        // Call the MoveBackward function within the mover class
        mover.MoveBackward(moveSpeed);
    }

    // Override and define the RotateClockwise function
    public override void RotateClockwise()
    {
        // Call the RotateClockwise function within the mover class
        mover.RotateClockwise(turnSpeed);
    }

    // Override and define the RotateCounterClockwise function
    public override void RotateCounterClockwise()
    {
        // Call the RotateClockwise function within the mover class
        mover.RotateCounterClockwise(turnSpeed);
    }
}
