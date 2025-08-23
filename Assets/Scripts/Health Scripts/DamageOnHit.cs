using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    // Create a variable to store the amount of damage done on hit
    public float damageDealtOnHit;
    // Create a variable to control the length of time a projectile will exist
    public float lifespan = 2;

    // Create a variable to track who the projectile was fired by
    public Pawn shotOwner;

    // Check if our collider has hit any other objects
    public void OnTriggerEnter(Collider other)
    {
        // Get the health component data from the object that triggered our collider
        Health otherHealth = other.GetComponent<Health>();

        // Check to see if the other object that was collided with has a health component
        if (otherHealth != null )
        {
            // Damange the other component this object collided with
            otherHealth.TakeDamage(damageDealtOnHit, shotOwner);
        }

        // Destroy the bullet when it collides
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Destroy the projectile after the lifespan has concluded/reached 0
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
