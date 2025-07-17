using UnityEngine;

// This class inherits from the Death parent class; Which is an abstract class
public class DestroyOnDeath : Death
{
    // Define the Die function to destroy the player on death
    public override void Die()
    {
        // Delete or Remove the game object from the scene
        Destroy(gameObject);
    }
}
