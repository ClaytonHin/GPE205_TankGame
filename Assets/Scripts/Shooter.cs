using UnityEngine;

// Make this class abstract, so we can have multiple types of shooters
public abstract class Shooter : MonoBehaviour
{
    public abstract void Shoot(Pawn shooterPawn);

    public abstract void TryShoot(Pawn shooterPawn);
}
