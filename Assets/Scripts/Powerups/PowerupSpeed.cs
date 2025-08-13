using UnityEngine;

[System.Serializable]
public class PowerupSpeed : Powerup
{
    // Create a variable to store the amount of speed we want to add 
    public float speedBoostAmount;

    // Override the apply function from the Powerup Parent class
    public override void Apply(PowerupManager target)
    {
        // Get the target pawns component
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();

        // Check to see if the target has a pawn component attached
        if (targetPawn != null )
        {
            // Increase the movement speed of the pawn based on the speed boost amount
            targetPawn.moveSpeed += speedBoostAmount;
        }
    }

    // Override the remove function from the Powerup Parent class
    public override void Remove(PowerupManager target)
    {
        // Get the target pawns component
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();

        // Check to see if the target has a pawn component attached
        if (targetPawn != null)
        {
            // Decrease the movement speed of the pawn based on the speed boost amount
            targetPawn.moveSpeed -= speedBoostAmount;
        }
    }
}
