using UnityEngine;

[System.Serializable]
public class PowerupShotSpeed : Powerup
{
    // Create a variable to store the shot speed to be added
    public float shotSpeedAmount;

    // Override the apply function from the Powerup Parent class
    public override void Apply(PowerupManager target)
    {
        // Get the target pawns component
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();

        // Check to see if the target has a pawn component attached
        if (targetPawn != null)
        {
            // Increase the movement speed of the pawn based on the speed boost amount
            targetPawn.shotsPerSecond += shotSpeedAmount;
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
            targetPawn.shotsPerSecond -= shotSpeedAmount;
        }
    }
}
