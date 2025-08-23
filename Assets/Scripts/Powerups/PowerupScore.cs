using UnityEngine;

[System.Serializable]
public class PowerupScore : Powerup
{
    // Create a variable to store the amount of score to add 
    public int scoreToAdd;

    // Override the apply function from the Powerup Parent class
    public override void Apply(PowerupManager target)
    {
        // Get the target pawns component
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();

        // Check to see if the target has a pawn component attached
        if (targetPawn != null)
        {
            // Grab the player controller component from the target pawn's controller
            PlayerController playerController = targetPawn.controller as PlayerController;
            // If there is a player controller attached
            if (playerController != null)
            {
                // Add to the players score
                playerController.AddScore(scoreToAdd);
            }
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
            // Grab the player controller component from the target pawn's controller
            PlayerController playerController = targetPawn.controller as PlayerController;
            // If there is a player controller attached
            if (playerController != null)
            {
                // Add to the players score
                playerController.AddScore(-scoreToAdd);
            }
        }
    }
}
