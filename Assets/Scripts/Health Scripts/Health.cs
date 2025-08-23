using JetBrains.Annotations;
using System.Security.Cryptography;
using Unity.Hierarchy;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Create a variable for the maximum health the object has
    public float maxHealth;
    // Create a variable to store the current health of the object
    public float currentHealth;
    // Create a new variable to attach our death component when the player runs out of health
    private Death deathComponent;
    // Create a variable to hold the audio source for the sound when a tank takes damage
    private AudioSource audioSource;
    // Create a variable to hold the sound clip that plays when a tank takes damage
    public AudioClip takeDamageSoundClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Retrieve the Death component for the object this component is attached to
        deathComponent = GetComponent<Death>();

        // Start with the object at max health
        currentHealth = maxHealth;

        // Get the audio source component from the parent object
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float incomingDamage)
    {
        // Call the other take damage function, and pass in null for for the shot source 
        TakeDamage(incomingDamage, null);
    }

    // Create a function to take damage, and pass in how much damage the object should take as a parameter
    public void TakeDamage(float incomingDamage, Pawn shotSource)
    {
        // Whenever a tank takes damage, play the damage sfx
        if (audioSource != null)
        {
            audioSource.PlayOneShot(takeDamageSoundClip);
        }

        // Reduce our health based on the total amount of incoming damage
        currentHealth -= incomingDamage;
        
        // Clamp our damage value so it stays within the range of our minimum and maximum health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Check to see if the object is below 0 HP
        if (currentHealth <= 0)
        {
            // Call the Die function within the Death Class
            Die(shotSource);
        }
    }

    // Create a public die function
    public void Die(Pawn shotSource)
    {
        // Check to see if the shot source and the controller that shot it are valid
        if (shotSource != null && shotSource.controller != null)
        {
            // Assign the player controller that killed this object to a temporary variable
            PlayerController tempPlayerController = shotSource.controller as PlayerController;
            // If the player controller is valid
            if (tempPlayerController != null)
            {
                // Add 10 points to the player's score
                tempPlayerController.AddScore(10);
            }
        }

        // Get the player controller component from the object that is dying
        PlayerController playerController = GetComponent<PlayerController>();

        // Check to ensure that the player controller is valid
        if (playerController != null)
        {
            // Reduce the player's total lives by 1
            playerController.lives -= 1;
            // Update the UI to show the player's remaining lives
            GameplayUI.instance.UpdateLivesText(playerController.lives);

            if (playerController.lives <= 0)
            {
                // Change the UI to the Loss/Defeat screen
                GameManager.instance.PlayerLost(playerController);

                // Execute any death logic if it exists
                deathComponent?.Die(shotSource);
                return;
            }
            else // The player still have lives left, so respawn them
            {
                // Check to ensure the object has a deathComponent and has a respawn script 
                if (deathComponent != null && deathComponent is RespawnOnDeath respawnScript)
                {
                    // Respawn the player
                    respawnScript.RespawnPlayer();
                }
                else
                {
                    // If there is no death component
                    Vector3 tempSpawnPosition = GameManager.instance.GetRespawnPoint().position;
                    // Move the player to the random respawn point
                    transform.position = tempSpawnPosition;
                    // Set their health back to max
                    currentHealth = maxHealth;
                }
                // Return to avoid destroying the object
                return;
            }
        }
        // Fallback Die if there is no player controller detected. 
        deathComponent?.Die(shotSource);
    }
}
