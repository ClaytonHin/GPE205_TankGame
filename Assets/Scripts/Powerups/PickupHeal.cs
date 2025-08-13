using UnityEngine;

public class PickupHeal : MonoBehaviour
{
    // Create a powerupHeal variable
    public PowerupHeal powerup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider otherObject)
    {
        // Create a variable to store the powerupManager component value of the target hit
        PowerupManager otherPowerupManager = otherObject.gameObject.GetComponent<PowerupManager>();

        // Check to ensure the hit target has the PowerupManager component attached to it
        if (otherPowerupManager != null )
        {
            // If the target has a powerupManager component, then add the powerup effect to the target who collided with this powerup
            otherPowerupManager.AddPowerup(powerup);
        }

        // Destroy this object
        Destroy(gameObject);
    }
}
