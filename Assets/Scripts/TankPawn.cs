using UnityEngine;
// Include the System.Collections.Generic library to access extra functionality
using System.Collections.Generic;
public class TankPawn : Pawn
{
    // Awake is run when the object is first created
    public void Awake()
    {
        // Add this pawn to the GameManager list
        GameManager.instance.pawns.Add(this);
        // Change the name of the object that is created, so it is easier to differentiate between them when they are all in one scene
        gameObject.name = "TankPawn " + GameManager.instance.pawns.Count;
    }

    // Create and define our overload functions
    public override void Start()
    {
        //Get the mover component for the object this component is attached to / the tank
        mover = GetComponent<Mover>();
    }
    public override void Update()
    {
    }

    // OnDestroy runs whenever the object is destroyed/deleted from the scene
    public void OnDestroy()
    {
        // Remove our tank pawn from the list whenever it is destroyed/removed from the scene
        GameManager.instance.pawns.Remove(this);
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
