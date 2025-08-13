//Searialize this entire class so it is visible within the inspector
[System.Serializable]

public abstract class Powerup
{
    // Create a variable to store if a powerup is permanent within the game scene
    public bool isPermanent;
    // Create a variable to store the total duration powerups can exists for within the scene
    public float powerupDuration;
    // Create a function that will apply a powerup to the target specified
    public abstract void Apply(PowerupManager target);

    // Create a function that will remove a powerup from the target specified
    public abstract void Remove(PowerupManager target);

}
