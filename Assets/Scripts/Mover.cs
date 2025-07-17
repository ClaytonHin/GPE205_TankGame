using UnityEngine;

// Create a abstrct class method that NEVER exist on its own, it will always need a child attached;
public abstract class Mover : MonoBehaviour
{
    // In abstract classes there is no need to define what these methods will do. This is exactly the same as constructors in C++
    // The children of this class will define their own functionality for how these methods should functionally work
    public abstract void Start();
    public abstract void Update();
    public abstract void MoveForward(float moveSpeed);
    public abstract void MoveBackward(float moveSpeed); 
    public abstract void RotateClockwise(float turnSpeed);
    public abstract void RotateCounterClockwise(float turnSpeed);
}
