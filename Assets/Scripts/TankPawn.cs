// Include the System.Collections.Generic library to access extra functionality
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
public class TankPawn : Pawn
{
    // Awake is run when the object is first created
    public void Awake()
    {
    }

    // Create and define our overload functions
    public override void Start()
    {
        // Get the mover component for the object this component is attached to / the tank
        mover = GetComponent<Mover>();
        
        // Get the shooter component for the object this component is attached to
        shooter = GetComponent<Shooter>();

        // Get the health component for the object this component is attached to
        health = GetComponent<Health>();

        // Add this pawn to the GameManager list
        GameManager.instance.pawns.Add(this);
        // Change the name of the object that is created, so it is easier to differentiate between them when they are all in one scene
        gameObject.name = "TankPawn " + GameManager.instance.pawns.Count;
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

    // Override and define the rotateTowards Function
    public override void RotateTowards(Vector3 targetPosition)
    {
        // NOTE: To find the difference between the targets:
        // Take the end position/vector and subtract it's value from the starting position/vector
        Vector3 vectorToTarget = targetPosition - this.transform.position;

        // Find the direction needed to rotate the AI Pawn to face the vectorToTarget's value
        Quaternion rotationVector = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        // Modify the rotation to smoothly transition from the current rotation, and the updated rotationVector value
        // We can use a quanternion to achieve this smooth transition based on the game's frame rate
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotationVector, this.turnSpeed * Time.deltaTime);

    }



    // Override and define the Shoot function
    public override void Shoot()
    {
        // Call the shoot method defined withinn the shooter class
        shooter.TryShoot(this);
    }
}
