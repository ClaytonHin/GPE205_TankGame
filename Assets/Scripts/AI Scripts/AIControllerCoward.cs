using UnityEngine;

public class AIControllerCoward : AIController
{
    public float fleeDistance = 50;
    public float safeDistance = 25;
    [Range(0,1)]public float fleeHealthPercent = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Set our starting state
        ChangeState(AIStates.GUARD);

        // Attempt to find player[0] 
        TargetPlayerByNumber(0);
    }

    // Update is called once per frame
    public override void MakeDescisions()
    {
 

        // Define our FSM for this AI's Behavior
        switch (currentState)
        {
            case AIStates.GUARD:
                // Check to ensure our target has a value
                if (target == null)
                {
                    // If the target has no value currently, then try to target the player
                    TargetPlayerByNumber(0);
                }

                // Call the guard function if we are within the Guard state // DO THE WORK
                Guard();

                // Check for any transitions
                // Check if the player is within 50 meters from the AI
                if (IsTargetWithinDistance(safeDistance))
                {
                    // If the player is within 50 meters, transition states into BACKAWAYANDSHOOT
                    ChangeState(AIStates.BACKAWAYANDSHOOT);
                }
                break;

            case AIStates.BACKAWAYANDSHOOT:
                // Call the BackAway and Shoot functions if we have transitioned to this state
                BackAway();
                Shoot();

                // Check for any transitions
                // Check to see if the AI is below 50% health
                if (IsHealthBelowPercent(fleeHealthPercent))
                {
                    // If the AI's Health is below 50%, transition into the FLEE state
                    ChangeState(AIStates.FLEE);
                }
                // Check to see if the target/player is within 150 meters of the AI
                if (!IsTargetWithinDistance(fleeDistance))
                {
                    // If the target is further than 150 meters, than transition back into the GUARD state
                    ChangeState(AIStates.GUARD);
                }    
                break;

            case AIStates.FLEE:
                // Call the Flee function if we have transitioned into this state
                Flee();

                // Check for transitions
                // Check to see if we are above 50%
                if (!IsHealthBelowPercent(fleeHealthPercent))
                {
                    // If the health is restored/above 50%, then transition back into the BACKAWAYANDSHOOT state
                    ChangeState(AIStates.BACKAWAYANDSHOOT);
                }
                // Check to see if the target/player is within 150 meters of the AI
                if (!IsTargetWithinDistance(fleeDistance))
                {
                    // If the target is further than 150 meters, then transition back into the GUARD state
                    ChangeState(AIStates.GUARD);
                }
                break;
        }
    }
}
