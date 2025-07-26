using UnityEngine;

public class AIController : Controller
{
    // Create an enum of different states our AI can use / transition into
    public enum AIStates { GUARD, CHASE, CHASEANDSHOOT, FLEE, BACKAWAY, STANDANDSHOOT }
    // Create a AI state variable to know which state we are currently in
    public AIStates currentState;

    public override void Awake()
    {
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // When this script is started, start the AI state to be defaulted to the guard state
        currentState = AIStates.GUARD;
    }

    // Update is called once per frame
    public override void Update()
    {
        //Make Descisions based on the state of the AI
        MakeDescisions();
    }

    public void Guard()
    {
        // Do nothing
    }

    public void Flee()
    {
        // AI shoud turn away from the player, and move foward

        pawn.MoveForward();
    }

    public void BackAway()
    {
        // Turn towards the player pawn, and start moving backwards

        pawn.MoveBackward();
    }

    public void Shoot()
    {
        // Begin shooting at the player pawn
        pawn.Shoot();
    }    

    public void Chase()
    {
        // Turn/rotate until facing the player Pawn, and begin moving in their direction

        pawn.MoveForward();
    }


    public override void MakeDescisions()
    {
        // The standard AI can't do anything but guard
        Guard();
    }
}
