using UnityEngine;

public class TankMover : Mover
{
    // Create a private local variable to store the parents rigidbody component from its parent object (AKA the Tank's Rigidbody)
    public Rigidbody m_Rigidbody;

    // Override and define the mover functions
    public override void Start()
    {
        //Get the rigidbody compoment from the object this component is attached to, and store its value in the rigidbody variable within this class
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public override void Update()
    {
    }

    public override void MoveForward(float moveSpeed)
    {
        // Move the player foward by moving their transform position based on the movement speed and the frame rate 
        m_Rigidbody.MovePosition(m_Rigidbody.position + (transform.forward * moveSpeed * Time.deltaTime));
    }

    public override void MoveBackward(float moveSpeed)
    {
        // Move the player backwards from their current transform position based on their movement speed and the frame rate
        // This means we reverse our transform forward, and make its value negative to move backwards
        m_Rigidbody.MovePosition(m_Rigidbody.position + (-transform.forward * moveSpeed * Time.deltaTime));
    }

    public override void RotateClockwise(float turnSpeed)
    {
        // Rotate the object clockwise based on the turn speed and the frame rate
        // Ensure to only rotate around the y axis
        // Rotate takes 3 parameters (X rotation, Y rotation, Z rotation) 
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }

    public override void RotateCounterClockwise(float turnSpeed)
    {
        // Rotate the object counterclockwise based on the turn speed and the frame rate
        // We can achive this by flipping the turn speed value into a negative value. So it rotates left instead of right
        transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
    }
}
