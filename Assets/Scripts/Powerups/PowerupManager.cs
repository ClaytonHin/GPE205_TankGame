using UnityEngine;
using System.Collections.Generic;

public class PowerupManager : MonoBehaviour
{
    // Create a list of powerups that are currently within the game scene
    public List<Powerup> powerups;

    // Create a private list of powerups that are in queue to be removed
    private List<Powerup> removalList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Reset the powerups list
        powerups = new List<Powerup>();
        // Reset the removalPowerups list
        removalList = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers();
    }

    public void AddPowerup(Powerup powerupToAdd)
    {
        // Apply the powerup to the object
        powerupToAdd.Apply(this);
        // Save this powerup within the powerups list
        powerups.Add(powerupToAdd);
    }

    public void RemovePowerup(Powerup powerupToRemove)
    {
        // Remove the powerup from the object
        powerupToRemove.Remove(this);
        // Remove this powerup from the powerups list
        powerups.Remove(powerupToRemove);
    }

    public void DecrementPowerupTimers()
    {
        // Loop through our list of powerups
        foreach (Powerup powerup in powerups)
        {
            // Check to see if the power is NOT permanent before decreasing the duration total
            if (!powerup.isPermanent)
            {
                // Decrease the total duration based on the delta time
                powerup.powerupDuration -= Time.deltaTime;

                // Check to see if its duration is <= 0
                if (powerup.powerupDuration <= 0)
                {
                    // Add this powerup to the removal list, since the duration is done
                    removalList.Add(powerup);
                }
            }
        }
        // After we have iterated from the powerups list, we can remove from it without errors
        // Loop through the list of powerups that need removed
        foreach (Powerup powerup in removalList)
        {
            RemovePowerup(powerup);
        }
        // Ensure to clear the removal list so it is empty before being looped through again
        removalList.Clear();
    }







}
