using UnityEngine;

public abstract class Death : MonoBehaviour
{
    // Overload the default die function to accept a shot source parameter
    public abstract void Die(Pawn shotSource);
    
}
