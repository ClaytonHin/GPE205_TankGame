using UnityEngine;

// Create a abstrct class method that NEVER exist on its own, it will always need a child attached;
public abstract class Mover : MonoBehaviour
{

    public abstract void Start();

    // In abstract classes there is no need to define what these methods will do. This is exactly the same as constructors in C++
    // The children of this class will define their own functionality for how these methods should functionally work
    public abstract void Move(Vector3 moveVector);

    public abstract void Rotate(Vector3 rotateVector);
}
