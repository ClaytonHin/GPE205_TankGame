using UnityEngine;
// Include the System.Collections.Generic library to access extra functionality
using System.Collections.Generic;

//Make this class absctract, since we want any pawns to specifically be children of this class
public abstract class Pawn : MonoBehaviour
{
    // Create a public variable that will determine the pawns movement speed
    public float moveSpeed;
    // Create another public variable that will determine the pawns rotation speed
    public float turnSpeed;
    // Create a variable to control the amount of damage this pawn does to another object with health
    public float damageDone = 1;
    // Create a variable to control the force behind each shot
    public float shootForce = 200;
    // Create a variable to control the shots per second
    public float shotsPerSecond = 2;

    // Add the mover component to our pawn
    [HideInInspector] public Mover mover;
    // Add the shooting component to our pawn
    [HideInInspector] public Shooter shooter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();
    // Update is called once per frame
    public abstract void Update();
    // Create the outline for the movement functions, since they are within an abstract class
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    // Create an abstract function to shoot, this is abstract so we can define it in individual children classes
    public abstract void Shoot();
}
