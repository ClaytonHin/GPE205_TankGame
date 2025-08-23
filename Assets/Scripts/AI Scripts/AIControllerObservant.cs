using UnityEngine;

public class AIControllerObservant : AIController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Set our starting state
        ChangeState(AIStates.GUARD);

        // Attempt to find player[0] 
        TargetFirstAlivePlayer();

        // Add this pawn to the GameManager list
        GameManager.instance.aiControllers.Add(this);
        // Change the name of the object that is created, so it is easier to differentiate between them when they are all in one scene
        gameObject.name = "AIController " + GameManager.instance.pawns.Count;
    }

    // Update is called once per frame
    public override void Update()
    {
        // Define the switch case to handle the FSM behavior
        switch(currentState)
        {
            case AIStates.GUARD:
                // Do work
                Guard();
                if (target == null)
                {
                    TargetFirstAlivePlayer();
                }

                // Check for transitions
                if (CanHear(target))
                {
                    ChangeState(AIStates.CHASEANDSHOOT);
                }
                break;

            case AIStates.CHASEANDSHOOT:
                if (target == null)
                {
                    TargetFirstAlivePlayer();
                }
                // Do work
                Seek(target);
                Shoot();

                // Check for transitions
                if (!CanHear(target))
                {
                    ChangeState(AIStates.GUARD);
                }
                break;
        }
    }
}
