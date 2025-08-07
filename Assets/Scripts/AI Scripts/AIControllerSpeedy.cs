using UnityEngine;

public class AIControllerSpeedy : AIController
{

    public override void Start()
    {
        ChangeState(AIStates.GUARD);
        TargetPlayerByNumber(0);
    }

    // Finite State Machine Switch Case statements for the Speedy version of the AIController
    public override void MakeDescisions()
    {
        // Create a switch case to evaluate or change which state the AI is currently in / transisitioning to
        switch (currentState)
        {
            case AIStates.GUARD:
                // Do the work of the GUARD state
                Guard();
                // Check for any transition, and change if needed
                if (IsTargetWithinDistance(10))
                {
                    ChangeState(AIStates.CHASEANDSHOOT);
                }
                break;

            case AIStates.CHASEANDSHOOT:
                if (target == null)
                {
                    // If the target has no value currently, then try to target the player
                    TargetPlayerByNumber(0);
                }
                // Do the work of the CHASEANDSHOOT state
                Chase();
                Shoot();
                // Check for any transitions, and change if needed
                if (!IsTargetWithinDistance(10))
                {
                    ChangeState(AIStates.GUARD);
                }
                if (Time.time - lastStateChangeTime > 5)
                {
                    ChangeState(AIStates.GUARD);
                }

                break;
        }

    }
}
