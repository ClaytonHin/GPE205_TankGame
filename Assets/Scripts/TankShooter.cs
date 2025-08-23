using UnityEngine;

public class TankShooter : Shooter
{
    // Create a prefab for the projectile
    public GameObject projectilePrefab;
    // Get the position on where the object is shooting from
    public Transform shootPosition;
    // Create a variable to hold the noisemaker component
    private NoiseMaker noiseMaker;
    // Create a variable to store the amount of nise made when the object is shooting
    public float shootingNoiseVolume;
    // Create a variable to hold the audio source for the shooting sound
    public AudioSource audioSource;

    // Create a variable to hold the time between shots
    [HideInInspector] public float nextShootTime;

    public override void Start()
    {
        // Get the noisemaker component from the parent object
        noiseMaker = GetComponent<NoiseMaker>();
        // Get the audio source component from the parent object
        audioSource = GetComponent<AudioSource>();
    }

    public override void TryShoot(Pawn shooterPawn)
    {
        // Check if the current time is greater than the shoot time value
        if (Time.time > nextShootTime)
        {
            // Call the shoot function
            Shoot(shooterPawn);

        }
    }


    // Create a shoot function, that will create a projectile from the tank.
    // This will take in whatever object shot the projectile as a parameter
    public override void Shoot(Pawn shooterPawn)
    {
        // Create or instantiate the bullet with the potition, scale, and rotation from the shoot position/origin
        GameObject bulletObject = Instantiate<GameObject>(projectilePrefab, shootPosition.position, shootPosition.rotation);

        // Get the DamageOnHit component, and store it in a local variable
        DamageOnHit damageComponent = bulletObject.GetComponent<DamageOnHit>();

        // Grab the amount of damage done based on what value the pawn sends in
        damageComponent.damageDealtOnHit = shooterPawn.damageDone;

        // Set the shot owner to be the pawn that fired the projectile
        damageComponent.shotOwner = shooterPawn;

        // Get the rigidbody component for the projectile
        Rigidbody bulletRB = bulletObject.GetComponent<Rigidbody>();

        // Add force to the bullet in the forward direction, and move it based on the amount of shootForce
        bulletRB.AddForce(bulletObject.transform.forward * shooterPawn.shootForce);

        // Reset the shoot time variable, and devide our value to convert shotsPerSecond into secondsPerShot
        // EXAMPLE: If shotsPerSecond's value is 10, then you will shoot ever 1/10th of a second
        nextShootTime = Time.time + (1 / shooterPawn.shotsPerSecond);

        // Make noise if the noisemaker component is attached
        if (noiseMaker != null)
        {
            noiseMaker.MakeNoise(shootingNoiseVolume);
        }

        // Play the audio for shooting / creating a projectile
        audioSource.Play();
    }
}
