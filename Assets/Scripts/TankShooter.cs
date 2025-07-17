using UnityEngine;

public class TankShooter : Shooter
{
    // Create a prefab for the projectile
    public GameObject projectilePrefab;
    // Get the position on where the object is shooting from
    public Transform shootPosition;
    // Create a variable to store the amount of force the projectile has
    public float shootForce;

    // Create a shoot function, that will create a projectile from the tank.
    // This will take in whatever object shot the projectile as a parameter
    public override void Shoot()
    {
        // Create or instantiate the bullet with the potition, scale, and rotation from the shoot position/origin
        GameObject bulletObject = Instantiate<GameObject>(projectilePrefab, transform);

        // Get the DamageOnHit component, and store it in a local variable
        DamageOnHit damangeComponent = bulletObject.GetComponent<DamageOnHit>();

        // Get the rigidbody component for the projectile
        Rigidbody bulletRB = bulletObject.GetComponent<Rigidbody>();

        // Add force to the bullet in the forward direction, and move it based on the amount of shootForce
        bulletRB.AddForce(bulletObject.transform.forward * shootForce);
    }
}
