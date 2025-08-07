using UnityEngine;

public class AIControllerPatrol : AIController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Change the current state to be the partol state by default
        ChangeState(AIStates.PATROL);
        TargetPlayerByNumber(0);
    }

    public override void MakeDescisions()
    {
        switch (currentState)
        {
            case AIStates.PATROL:
                // Check to ensure our target has a value
                if (target == null)
                {
                    // If the target has no value currently, then try to target the player
                    TargetPlayerByNumber(0);
                }
                // Do Work
                Patrol();
                // Check for transitions
                // Check to ensure our target has a value
                if (IsTargetWithinDistance(10))
                {
                    ChangeState(AIStates.CHASEANDSHOOT);
                }
                // Break out of the case statment
                break;
            case AIStates.CHASEANDSHOOT:
                // Check to ensure our target has a value
                if (target == null)
                {
                    // If the target has no value currently, then try to target the player
                    TargetPlayerByNumber(0);
                }
                // Do work
                Chase();
                Shoot();
                // Check for transitions
                if (!IsTargetWithinDistance(10))
                {
                    ChangeState(AIStates.PATROL);
                }
                break;
        }
    }
}
