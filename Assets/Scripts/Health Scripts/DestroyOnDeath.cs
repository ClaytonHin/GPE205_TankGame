using UnityEngine;

// This class inherits from the Death parent class; Which is an abstract class
public class DestroyOnDeath : Death
{
    // Override the Die function to include who killed the object
    public override void Die(Pawn shotSource)
    {
        //Delete or Remove the game object from the scene
        Destroy(gameObject);
    }
}
