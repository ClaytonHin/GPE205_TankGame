using UnityEngine;

public class AIControllerPatrol : AIController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Change the current state to be the partol state by default
        ChangeState(AIStates.PATROL);
    }

    public override void MakeDescisions()
    {
        switch (currentState)
        {
            case AIStates.PATROL:
                // Do Work
                Patrol();
                // Break out of the case statment
                break;
        }
    }
}
