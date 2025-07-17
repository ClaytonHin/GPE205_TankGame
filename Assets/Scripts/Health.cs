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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Retrieve the Death component for the object this component is attached to
        deathComponent = GetComponent<Death>();

        // Start with the object at max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }

    // Create a function to take damage, and pass in how much damage the object should take as a parameter
    public void TakeDamage (float incomingDamage)
    {
        // Reduce our health based on the total amount of incoming damage
        currentHealth -= incomingDamage;
        
        // Clamp our damage value so it stays within the range of our minimum and maximum health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Check to see if the object is below 0 HP
        if (currentHealth <= 0)
        {
            // Call the Die function within the Death Class
            Die();
        }
    }

    // Create a public die function
    public void Die()
    {
        // Call the die function from the Death component
        deathComponent.Die();
    }
}
