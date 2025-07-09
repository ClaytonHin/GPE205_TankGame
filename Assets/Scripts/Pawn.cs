using UnityEngine;

//Make this class absctract, since we want any pawns to specifically be children of this class
public abstract class Pawn : MonoBehaviour
{
    // Create a public variable that will determine the pawns movement speed
    public float moveSpeed;

    // Create another public variable that will determine the pawns rotation speed
    public float rotateSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();

    // Create a public method for moving the pawn, and pass in a direction vector so the pawn moves in the correct direction
    public abstract void Move(Vector3 directionVector);

    // Create another public method to handle pawn rotation
    // Pass this method the value we want the yaw to be in terms of pawn rotation, so we can swivel the tank around it's Y axis. 
    public abstract void Rotate(Vector3 rotateVector);
}
