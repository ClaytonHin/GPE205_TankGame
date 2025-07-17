using UnityEngine;

//Make this class absctract, since we want any pawns to specifically be children of this class
public abstract class Pawn : MonoBehaviour
{
    // Create a public variable that will determine the pawns movement speed
    public float moveSpeed;
    // Create another public variable that will determine the pawns rotation speed
    public float turnSpeed;

    // Add the mover component to our pawn
    [HideInInspector] public Mover mover;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();
    // Update is called once per frame
    public abstract void Update();
    // Create the outline for the movement functions, since they are within an abstract class
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}
