using UnityEngine;

public class PickupScore : MonoBehaviour
{
    // Create a PowerupScore variable
    public PowerupScore powerup;

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
        // Check to ensure the powerupManager exists on the target object
        if (otherPowerupManager != null)
        {
            // If it does exists then add its powerup value to the powerupManager
            otherPowerupManager.AddPowerup(powerup);
        }
        // Destroy the pickup object
        Destroy(gameObject);
    }
}
