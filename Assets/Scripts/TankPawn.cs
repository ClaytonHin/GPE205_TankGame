using UnityEngine;

public class TankPawn : Pawn
{
    //NOTE: Controller Class Info -> TankPawn Class Info -> TankMover Class Info

    // Create a tank mover object locally within this class
    private TankMover mover;
    // Define our Move function and modify how our tank pawn specifically should move / rotate
    public override void Move(Vector3 directionVector)
    {
        // Call the controller move method when the pawn needs to be moved/updated
        mover.Move(directionVector);
    }


    public override void Rotate(Vector3 rotateVector)
    {
        // Call the controller rotate method when the pawn requests to rotate/update
        mover.Rotate(rotateVector);
    }


    protected override void Start()
    {
        // Grab the tank mover component from the parent object and store it within our local mover object.
        mover = GetComponent<TankMover>();
    }


    protected override void Update()
    {

    }
}
