using UnityEngine;

public class RespawnOnDeath : Death
{
    // Create a variable to store the delay between player death and the player respawning
    public float respawnDelay = 3f;
    // Create a variable to hold a timer of how long is left until the player respawns
    private float respawnTimer = 0f;
    // Create a variable to store if the player is currently dead or not
    private bool isDead = false;
    // Create a variable to store the pawn information about the dead/respawning pawn
    private Pawn deadPawn;
    // Create a variable to access the PlayerController's camera
    private PlayerController pawnController;

    public void Update()
    {
        // Check if the player is dead
        if (isDead && deadPawn != null)
        {
            // Decrement the respawn timer by the amount of time that has passed
            respawnTimer -= Time.deltaTime;
            // If the respawn timer is up / at 0
            if (respawnTimer <= 0f)
            {
                RespawnPlayer();
            }
        }
    }

    public override void Die(Pawn shotSource)
    {
        // Check if the shotSource pawn data was passed correctly
        if (shotSource != null)
        {
            // Set our deadPawn to the shotSource that was passed in. This is the pawn that died
            deadPawn = shotSource;
            // Create a variable and store the controller of the dead pawn that came in as a parameter
            pawnController = shotSource.controller as PlayerController;

            // Deactivate the pawn instead of destroying it
            deadPawn.gameObject.SetActive(false);

            // Set the timer based on the total respawn delay
            respawnTimer = respawnDelay;
            // Flip isDead
            isDead = true;
        }
    }

    // Create a function to respawn the player
    public void RespawnPlayer()
    {
        // Check to ensure we have a dead pawn, and the game manager instance
        if (deadPawn != null && GameManager.instance != null)
        {
            // Get a Vector 3 position from the random respawn points
            Vector3 randomSpawnPosition = GameManager.instance.GetRespawnPoint().position;

            // Move the dead pawn to the random spawn point
            deadPawn.transform.position = randomSpawnPosition;
            deadPawn.transform.rotation = Quaternion.identity;

            // Reactivate the dead Pawn object
            deadPawn.gameObject.SetActive(true);

            // Check if this pawn has a player controller with a camera, if so then reattach the camera
            if (pawnController != null && pawnController.playerCamera != null)
            {
                // Repossess the dead pawn
                pawnController.Possess(deadPawn);
            }

            // Reset the dead pawn value
            deadPawn = null;
            // Reset is dead
            isDead = false;
        }
    }
}
