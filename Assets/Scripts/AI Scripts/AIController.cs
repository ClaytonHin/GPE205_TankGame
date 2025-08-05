using UnityEngine;

public class AIController : Controller
{
    // Create an enum of different states our AI can use / transition into
    public enum AIStates { GUARD, CHASE, CHASEANDSHOOT, FLEE, BACKAWAY, BACKAWAYANDSHOOT, STANDANDSHOOT }
    // Create a AI state variable to know which state we are currently in
    public AIStates currentState;
    // Create a float variable to store the amount of time it has been since the last state change
    protected float lastStateChangeTime;
    // Create a object to store the target we are shooting, or fleeing from
    protected GameObject target;

    public override void Awake()
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // When this script is started, start the AI state to be defaulted to the guard state
        currentState = AIStates.GUARD;

        target = GameManager.instance.players[0].pawn.gameObject;
    }

    // Update is called once per frame
    public override void Update()
    {
        //Make Descisions based on the state of the AI
        MakeDescisions();
    }

    // Create a boolian function that will return if the health is below 50%
    public bool IsHealthBelowPercent(float healthPercent)
    {
        float currentHealthPercentage = pawn.health.currentHealth / pawn.health.maxHealth;

        // Divide the current health by the max health to get a percentage of the HP left
        if (currentHealthPercentage <= healthPercent)
        {
            // If the health is less than or equal to 50%
            return true;
        }
        else
        {
            // If the health is greater than 50%
            return false;
        }
    }

    // Create a boolian function that will check the distance the AI is from it's target
    public bool IsTargetWithinDistance(float distance)
    {
        // Check if our AI pawns position, and the target/player position has a value less than the distance parameter
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            // If the distance between the two transforms is less than the distance 
            return true;
        }
        else
        {
            // If the distance between the two transform is greater than the distance 
            return false;
        }
    }

    // Create a change state function that will transition the AI FSM between the different states when neccessary
    public void ChangeState(AIStates newState)
    {
        // Change the current state
        currentState = newState;

        // Save the time so we can check when our last Stage Change 
        lastStateChangeTime = Time.time;
    }

    // Create a function that will target a player based on their player number within the game manager instance
    public void TargetPlayerByNumber(int playerNumber)
    {
        // Check to ensure that the game manager exists
        if (GameManager.instance != null)
        {
            // If game manager exists, check to ensure that there are any players
            if (GameManager.instance.players.Count > 0)
            {
                // If we find players that exist, check to ensure that that players number within the game manager instance 
                if (GameManager.instance.players[playerNumber] != null)
                {
                    // Once we have confirmed all checks, set our target to be the player that was found or player[0]
                    target = GameManager.instance.players[playerNumber].pawn.gameObject;
                    // Exit this function since we already have our target value
                    return;
                }
            }
        }

        //Debug.LogWarning("ERROR: COULD NOT TARGET PLAYER + " + playerNumber);

    }

    public void Guard()
    {
        // Rotate the AI Pawn
        pawn.RotateClockwise();

        // If there is no current target, look for player[0] 
        if (target == null)
        {
            TargetPlayerByNumber(0);
        }
    }

    public void Chase()
    {
        // Turn towards the target position
        pawn.RotateTowards(target.transform.position);

        // Move the AI Pawn forward
        pawn.MoveForward();
    }

    public void Flee()
    {
        // Find the initial vector to the target, and use it's value to find a negative point in "Vector Space" behind the AI Pawn's initial vector.
        // We can find this negative point by multiplying the vectors by -1, which flips the vector's direction
        Vector3 vectorToTarget = -1 * (target.transform.position - pawn.transform.position);

        // Add our pawn's current position and the negative vector from above, and rotate towards that outcome vector value
        pawn.RotateTowards(pawn.transform.position + vectorToTarget);

        // Move the AI pawn backwards
        pawn.MoveForward();
    }

    public void Shoot()
    {
        // Begin shooting at the player pawn
        pawn.Shoot();
    }

    public void BackAway()
    {
        // Turn/rotate until facing the player, and then move backwards
        pawn.RotateTowards(target.transform.position);

        // Move Backwards
        pawn.MoveBackward();
    }

    public override void MakeDescisions()
    {
        // The standard AI can't do anything but guard
        Guard();
    }
}
