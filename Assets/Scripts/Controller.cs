using UnityEngine;

// Keep the MonoBehavior parent class so our Controller children classes inherit all of the methods and properties from that class
public class Controller : MonoBehaviour
{
    // Create and define the body the controller will "control/use" so it can be used for multiple objects with the same code
    // Set this to public so it can be accessed outside of this class, {This also serializes this data, which allows it to be accessed/modified within the editor}
    // NOTE: You can serialize private properties by using [SerializeField] before the private declaration
    public Pawn pawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
