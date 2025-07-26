using UnityEngine;

public class AIControllerSpeedy : AIController
{
    // Finite State Machine Switch Case statements for the Speedy version of the AIController
    public override void MakeDescisions()
    {
        // Create a switch case to evaluate or change which state the AI is currently in / transisitioning to
        switch (currentState)
        {
            // Create cases to check the current state, and execute functions based on that specific state
            case AIStates.GUARD:
                // Do work
                Guard();
                // TODO: Check for transitions
                break;

            case AIStates.FLEE:
                // Do work
                Flee();
                // TODO: Check for transitions
                break;

            case AIStates.BACKAWAY:
                // Do work
                BackAway();
                // TODO: Check for transitions
                break;

            case AIStates.STANDANDSHOOT:
                // Do work
                Shoot();
                // TODO: Check for transitions
                break;

            case AIStates.CHASE:
                // Do work
                Chase();
                // TODO: Check for transitions
                break;

            case AIStates.CHASEANDSHOOT:
                // Do work
                Chase();
                Shoot();
                // TODO: Check for transitions
                break;

            default:
                // Do nothing if it is not in any of the above states
                break;
        }

    }
}
