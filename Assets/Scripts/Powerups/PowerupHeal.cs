using UnityEngine;

// Serialize this entire class
[System.Serializable]
public class PowerupHeal : Powerup
{
    // Create a variable that will store the amount of health to heal for the pickup
    public float amountToHeal;

    // Override the apply function from the Powerup Parent class
    public override void Apply(PowerupManager target)
    {
        // Get the taget objects health component
        Health targetHealthComponent = target.gameObject.GetComponent<Health>();
        // Check to see if the target has a health component attached
        if (targetHealthComponent != null )
        {
            // If the target has a health component then heal the target by making them take a negative damage value
            targetHealthComponent.TakeDamage(-amountToHeal);
        }    
    }

    // Override the remove function from the Powerup Parent class
    public override void Remove(PowerupManager target)
    {
        // Get the target objects health component
        Health targetHealthComponent = target.gameObject.GetComponent<Health>();
        // Check to see if the target has a health component
        if (targetHealthComponent != null )
        {
            // If it has a health component then deal damage to the target based on the amount to heal
            targetHealthComponent.TakeDamage(amountToHeal);
        }

    }
}
